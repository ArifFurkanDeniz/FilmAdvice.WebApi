using FilmAdvice.Domain.Api;
using FilmAdvice.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace FilmAdvice.Business.Interfaces
{
    public interface IAccountService
    {
        /// <summary>
        /// User auth
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        ResultModel<TokenApiResponse> Login(LoginApiRequest model);

    }
}
