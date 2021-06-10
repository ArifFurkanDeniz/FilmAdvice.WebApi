using FilmAdvice.Business.Interfaces;
using FilmAdvice.Core.Security;
using FilmAdvice.Domain.Api;
using FilmAdvice.Domain.Common;
using FilmAdvice.Domain.Dto;
using FilmAdvice.Entities.Model;
using FilmAdvice.Repository.Generic;
using FilmAdvice.Repository.UnitOfWork;
using System;
using System.Collections.Generic;

using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using FilmAdvice.Repository.Extensions;
using Microsoft.Extensions.Configuration;


namespace FilmAdvice.Business
{
    public class AccountService : IAccountService
    {
        private readonly IRepository<WebUser> _webUsersRepository;

        private readonly IUnitOfWork _unitOfWork;
        private readonly ITokenService _tokenService;


        public AccountService(IRepository<WebUser> webUsersRepository, ITokenService tokenService)
        {
            _webUsersRepository = webUsersRepository;
            _tokenService = tokenService;          

        }

        public ResultModel<TokenApiResponse> Login(LoginApiRequest model)
        {
            var user = _webUsersRepository.Find(x => x.Email == model.Email && x.Password == model.Password.ToMd5() && x.StatusId == 1).FirstOrDefault();

            if (user == null)
            {
                return new ResultModel<TokenApiResponse>(false, "User not found");
            }

            var userDto = new UserDto
            {
                Email = user.Email,
                FullName = user.FullName,
                Id = user.Id,
                Title = user.Title
            };

            var result = new ResultModel<TokenApiResponse>(_tokenService.GenerateToken(userDto));

            result.Data.UserData = userDto;

            return result;

        }
    }
}
