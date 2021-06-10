using FilmAdvice.Domain.Api;
using FilmAdvice.Domain.Common;
using FilmAdvice.Domain.Dto;
using FilmAdvice.Entities.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FilmAdvice.Business.Interfaces
{
    public interface IFilmService : IBaseService<Film>
    {
        /// <summary>
        /// Get films from api and insert to database
        /// </summary>
        /// <returns></returns>
        Task<ResultModel> FilmPull();

        /// <summary>
        ///  Returns film list from database by paging
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        ResultModel<PagingModel<List<FilmDto>>> GetFilmList(PagingDataApiRequest model);

        /// <summary>
        /// Add an note and score to film
        /// </summary>
        /// <param name="model"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        ResultModel AddComment(AddCommentApiRequest model, int userId);

        /// <summary>
        /// Get film and user note with avarage score
        /// </summary>
        /// <param name="filmId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        ResultModel<FilmDto> GetFilm(int filmId, int userId);

        /// <summary>
        /// Sends a film through e-mail
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        ResultModel Advice(AdviceFilmApiRequest model);
    }
}
