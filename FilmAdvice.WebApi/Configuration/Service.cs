using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using FilmAdvice.Core.Security;
using FilmAdvice.Repository.Generic;
using FilmAdvice.Repository.UnitOfWork;
using FilmAdvice.Business.Interfaces;
using FilmAdvice.Business;
using FilmAdvice.ApiClient.Interfaces;
using FilmAdvice.ApiClient;

namespace FilmAdvice.Api.Configuration
{
    public static class Service
    {
        /// <summary>
        /// </summary>
        /// <param name="services"></param>
        public static void AddMyServices(this IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IFilmService, FilmService>();
            services.AddScoped<IMovieApi, MovieApi>();

        }
    }
}
