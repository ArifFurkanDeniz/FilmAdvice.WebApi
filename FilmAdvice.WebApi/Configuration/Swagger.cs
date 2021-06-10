using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerUI;
using Microsoft.OpenApi.Models;
using System;

namespace FilmAdvice.WebApi.Configuration
{
    public static class Swagger
    {
        public static IServiceCollection AddMySwagger(this IServiceCollection services)
        {

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "FilmAdvice Api",
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                  
                });
            });

            return services;
        }

        public static IApplicationBuilder UseMySwagger(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "FilmAdvice.WebApi V1");
                c.DocumentTitle = "Title";
                c.DisplayOperationId();
                c.DocExpansion(DocExpansion.None);

            });

            return app;
        }
    }
}
