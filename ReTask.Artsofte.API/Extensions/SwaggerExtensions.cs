using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;

namespace ReTask.Artsofte.API.Extensions
{
    public static class SwaggerExtensions
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSwaggerGen(c =>
            {
                //c.IncludeXmlComments(string.Format(@"{0}\ReTask.Arfsofte.API.xml", AppDomain.CurrentDomain.BaseDirectory), true);
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "ReTask Artsofte API",
                    Description = "Переделанное с нуля задание Artsofte.",
                    Contact = new OpenApiContact
                    {
                        Name = "bratistolf",
                        Email = "bratistolf@gmail.com",
                        Url = new Uri("https://bratistolf.online/contact"),
                    }
                });
            });

            return services;
        }
    }
}
