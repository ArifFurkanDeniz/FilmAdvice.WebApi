using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using FilmAdvice.WebApi.Controllers;
using FilmAdvice.Business.Interfaces;
using FilmAdvice.Core.Security;
using FilmAdvice.Domain.Api;
using FilmAdvice.Domain.Common;
using FilmAdvice.Domain.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Serilog;

namespace FilmAdvice.WebApi.Controllers
{

    [AllowAnonymous]
    public class AccountController : BaseController<IAccountService>
    {
        private readonly IConfiguration configuration;
 
        public AccountController(IConfiguration iConfig, IAccountService service) : base(service)
        {
            configuration = iConfig;
        } 

        [HttpPost]
        [Route("login")]
        public ActionResult<ResultModel<TokenApiResponse>> Login([FromBody] LoginApiRequest model)
        {           
            var result = _service.Login(model);
         
            return result;
        }
    }
}