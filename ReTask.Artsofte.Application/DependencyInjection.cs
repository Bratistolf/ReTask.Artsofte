using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ReTask.Artsofte.Application.Common.Behaviours;
using ReTask.Artsofte.Application.Common.Mappings;
using System.Reflection;

namespace ReTask.Artsofte.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            var mappingConfig = new AutoMapperConfig().Configure();
            var mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));

            return services;
        }
    }
}
