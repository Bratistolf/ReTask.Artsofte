using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using ReTask.Artsofte.Application.Common.Interfaces;
using ReTask.Artsofte.Domain.Entities;
using System.Collections.Generic;
using System.IO;

namespace ReTask.Artsofte.Infrastructure.Persistence
{
    public class DbInitializer : IDbInitializer
    {
        private readonly IServiceScopeFactory _scopeFactory;

        public DbInitializer(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }

        public void Initialize(IConfiguration configuration)
        {
            if (!configuration.GetValue<bool>("UseInMemory"))
            {
                using var serviceScope = _scopeFactory.CreateScope();
                using var context = serviceScope.ServiceProvider.GetService<ArtsofteDbContext>();
                context.Database.Migrate();
            }
        }

        public void SeedData()
        {
            using var serviceScope = _scopeFactory.CreateScope();
            using var context = serviceScope.ServiceProvider.GetService<ArtsofteDbContext>();

            List<Language> languages;
            using (StreamReader r = new StreamReader("languages.json"))
            {
                string json = r.ReadToEnd();
                languages = JsonConvert.DeserializeObject<List<Language>>(json);
            }

            context.AddRange(languages);
            context.SaveChanges();
        }
    }
}
