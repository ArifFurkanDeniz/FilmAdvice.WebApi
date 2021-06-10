using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using FilmAdvice.Domain.Validation;

namespace FilmAdvice.WebApi.Configuration
{
    public static class Validator
    {
        public static void AddMyValidator(this IServiceCollection services)
        {
            services.AddSingleton<IValidator<FilmAdvice.Domain.Api.LoginApiRequest>, LoginApiRequestValidator>();
            services.AddSingleton<IValidator<FilmAdvice.Domain.Api.AddCommentApiRequest>, AddCommentApiRequestValidator>();
            services.AddSingleton<IValidator<FilmAdvice.Domain.Api.AdviceFilmApiRequest>, AdviceFilmApiRequestValidator>();
        }
    }
}
