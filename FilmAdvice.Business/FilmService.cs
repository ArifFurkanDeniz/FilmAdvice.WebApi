
using FilmAdvice.ApiClient.Interfaces;
using FilmAdvice.Business.Interfaces;
using FilmAdvice.Domain.Api;
using FilmAdvice.Domain.Common;
using FilmAdvice.Domain.Dto;
using FilmAdvice.Entities.Model;
using FilmAdvice.Repository.Extensions;
using FilmAdvice.Repository.Generic;
using FilmAdvice.Repository.UnitOfWork;
using LuxuryResume.Business;
using Microsoft.Extensions.Configuration;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace FilmAdvice.Business
{
    public class FilmService : BaseService<Film>, IFilmService
    {
        private readonly IMovieApi movieApi;
        private readonly IRepository<FilmComment> filmCommentRepository;
        private readonly IConfiguration _config;
        public FilmService(IConfiguration config, IMovieApi _movieApi, IRepository<Film> repository, IRepository<FilmComment> _filmCommentRepository, IUnitOfWork _unitOfWork) : base(repository, _unitOfWork)
        {
            _config = config;
            movieApi = _movieApi;
            filmCommentRepository = _filmCommentRepository;
        }

        public async Task<ResultModel> FilmPull()
        {

            var result = await movieApi.GetMoviePopular();

            if (!result.Status)
            {
                return result;
            }

            _unitOfWork.GetDbContext().Films.RemoveRange(_repository.Find());

            foreach (var item in result.Data.results)
            {
                _repository.Save(new Film
                {
                    FilmApiId = item.id,
                    FilmName = item.title,
                    FilmInfo = item.overview,
                    ReleaseDate = item.release_date,
                }); 
            }

           return _unitOfWork.Commit();
        }

        public ResultModel<PagingModel<List<FilmDto>>> GetFilmList(PagingDataApiRequest model)
        {
          var data = _repository.Find().Skip(model.Page).Take(model.Pagesize).Select(x=> new FilmDto
          {
              FilmInfo = x.FilmInfo,
              FilmName = x.FilmName,
              Id = x.Id,
              ReleaseDate = x.ReleaseDate
          }).ToList();

            var pagingModel = new PagingModel<List<FilmDto>>(data);

            pagingModel.CurrentPage = model.Page;
            pagingModel.TotalPage = _repository.Find().Count() / model.Pagesize;

            return new ResultModel<PagingModel<List<FilmDto>>>(pagingModel);

        }

        public ResultModel AddComment(AddCommentApiRequest model, int userId)
        {
          
           var filmComment = new FilmComment()
            {
                Text = model.Text,
                Score = model.Score,
               FilmId = model.FilmId,
               UserId = userId
            };

            filmCommentRepository.Save(filmComment);
           return _unitOfWork.Commit();
           
        }

        public ResultModel<FilmDto> GetFilm(int filmId, int userId)
        {

            var data = _repository.Find(x => x.Id == filmId, y => y
             .Include(z => z.FilmComments)).Select(x => new FilmDto
             {
                 Id = x.Id,
                 FilmName = x.FilmName,
                 FilmInfo = x.FilmInfo,
                 ReleaseDate = x.ReleaseDate,
                 // only current user notes
                 FilmComments = x.FilmComments.Where(k=> k.UserId == userId).Select(y => new FilmCommentDto
                 {
                     Score = y.Score,
                     Text = y.Text
                 }).ToList(),
                 AvaragePoint = x.FilmComments.Count()!= 0 ? x.FilmComments.Sum(y=>y.Score) / x.FilmComments.Count() : 0
             }).FirstOrDefault();

            return new ResultModel<FilmDto>(data);
        }

        public ResultModel Advice(AdviceFilmApiRequest model)
        {
            var film = GetById(model.FilmId);

            if (film == null)
            {
                Log.Logger.Error("Film not found");
                return new ResultModel(false, "Film not found");
            }

            var fromAddress = new MailAddress(_config.GetValue<string>("MailSettings:FromMail"), "System");
            var toAddress = new MailAddress(model.Email, "To User");
            string fromPassword = _config.GetValue<string>("MailSettings:Password");
            string subject = "Film Advice";
            string body = string.Format("Film Name : {0}", film.FilmName);

            var smtp = new SmtpClient
            {
                Host = _config.GetValue<string>("MailSettings:Smtp"),
                Port = Convert.ToInt32(_config.GetValue<string>("MailSettings:Port")),
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = true,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                try
                {
                    smtp.Send(message);

                    return new ResultModel();
                }
                catch (System.Exception ex)
                {
                    Log.Logger.Error(ex.Message + ex.StackTrace);
                    return new ResultModel(false, ex.Message);
                }
               
            }
        }
    }
}
