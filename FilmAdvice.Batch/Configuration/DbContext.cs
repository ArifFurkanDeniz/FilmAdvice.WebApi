using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using FilmAdvice.Entities;

namespace FilmAdvice.Batch.Configuration
{
    public static class DbContext
    {
        public static void AddMyDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<FilmAdviceDBContext>(options => options.UseSqlServer(connectionString,  b => b.MigrationsAssembly("FilmAdvice.Api")));
        }
    }
}