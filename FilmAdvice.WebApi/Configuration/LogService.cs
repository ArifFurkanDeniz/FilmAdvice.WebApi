using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace FilmAdvice.WebApi.Configuration
{
    public static class LogService
    {
        public static IServiceCollection AddSeriLog(this IServiceCollection services, IConfiguration configuration)
        {
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .CreateLogger();

            return services;
        }
    }
}
