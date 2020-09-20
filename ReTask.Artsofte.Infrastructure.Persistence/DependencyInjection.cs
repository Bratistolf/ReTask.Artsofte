using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ReTask.Artsofte.Application.Common.Interfaces;
using ReTask.Artsofte.Domain.Entities;
using ReTask.Artsofte.Infrastructure.Persistence.Repositories;

namespace ReTask.Artsofte.Infrastructure.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            if (configuration.GetValue<bool>("UseInMemory"))
            {
                services.AddDbContext<ArtsofteDbContext>(options =>
                    options.UseInMemoryDatabase("MSConnectionString"));
            }
            else
            {
                // TODO: ...
            }

            services.AddScoped<IArtsofteDbContext>(provider => provider.GetService<ArtsofteDbContext>());

            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient(typeof(IGenericRepository<Employee>), typeof(EmployeeRepository));

            return services;
        }
    }
}
