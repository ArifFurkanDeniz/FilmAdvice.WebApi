using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using FilmAdvice.Core.Security;
using FilmAdvice.Core.Security.JwtSecurity;
using FilmAdvice.Entities.Model;


namespace FilmAdvice.WebApi.Configuration
{
    public static class Auth
    {
        /// <summary>
        /// Token işlemi için configration
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static void AddMyAuth(this IServiceCollection services, IConfiguration configuration)
        {
  
            JwtTokenDefinitions.LoadFromConfiguration(configuration);
            services.ConfigureJwtAuthentication();
            services.ConfigureJwtAuthorization();
        }
    }
}
