using FilmAdvice.Business.Interfaces;
using FilmAdvice.Domain.Api;
using FilmAdvice.Domain.Common;
using FilmAdvice.Domain.Dto;
using FilmAdvice.Repository.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FilmAdvice.WebApi.Controllers
{
    public class FilmController : BaseController<IFilmService>
    {
        public FilmController(IFilmService service) : base(service)
        {

        }

        [HttpGet]
        [Route("List")]
        public ActionResult<ResultModel<PagingModel<List<FilmDto>>>> Login(PagingDataApiRequest model)
        {
            var result = _service.GetFilmList(model);

            return result;
        }

        [HttpPost]
        [Route("AddComment")]
        public ResultModel AddComment(AddCommentApiRequest model)
        {
            var result = _service.AddComment(model, UserId);

            return result;
        }

        [HttpGet]
        [Route("Get")]
        public ActionResult<ResultModel<FilmDto>> Get(int filmId)
        {
            var result = _service.GetFilm(filmId, UserId);

            return result;
        }

        [HttpPost]
        [Route("Advice")]
        public ResultModel Advice(AdviceFilmApiRequest model)
        {
            var result = _service.Advice(model);

            return result;
        }
    }
}
