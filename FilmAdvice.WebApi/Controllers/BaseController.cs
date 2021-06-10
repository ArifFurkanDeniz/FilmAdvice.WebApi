using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using FilmAdvice.Domain.Api;
using FilmAdvice.Domain.Common;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FilmAdvice.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class BaseController : Controller
    {

    }
    
    public abstract class  BaseController<TService> : BaseController
    {
        protected int UserId 
        { 
            get 
            {
                if (User.Identity.IsAuthenticated)
                {
                    return Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);
                }
                return 0;
               
            }  
        }

        protected readonly TService _service;

        protected BaseController(TService service)
        {
            _service = service;
        }
    }
}