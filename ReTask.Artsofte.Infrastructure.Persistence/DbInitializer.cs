using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using ReTask.Artsofte.Application.Common.Interfaces;
using ReTask.Artsofte.Domain.Entities;
using ReTask.Artsofte.Domain.Enums;
using System;
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

            // TODO: Нормальный генератор сущностей.
            var employees = new List<Employee>()
            {
                new Employee { Name = "Алия", Surname = "Орлова", Age = 21, Gender = Gender.Female, LanguageId = 1 },
                new Employee { Name = "Антонина", Surname = "Новикова", Age = 21, Gender = Gender.Female, LanguageId = 2 },
                new Employee { Name = "Тимофей", Surname = "Краснов", Age = 21, Gender = Gender.Male, LanguageId = 3 },
                new Employee { Name = "Евгения", Surname = "Кузнецова", Age = 21, Gender = Gender.Female, LanguageId = 4 },
                new Employee { Name = "Екатерина", Surname = "Данилова", Age = 21, Gender = Gender.Female, LanguageId = 5 },
                new Employee { Name = "Егор", Surname = "Ларин", Age = 21, Gender = Gender.Male, LanguageId = 6 },
                new Employee { Name = "Гордей", Surname = "Андреев", Age = 21, Gender = Gender.Male, LanguageId = 7 },
                new Employee { Name = "Александр", Surname = "Морозов", Age = 21, Gender = Gender.Male, LanguageId = 8 },
                new Employee { Name = "Михаил", Surname = "Федоров", Age = 21, Gender = Gender.Male, LanguageId = 9 },
                new Employee { Name = "Николь", Surname = "Лобанова", Age = 21, Gender = Gender.Female, LanguageId = 10 },
                new Employee { Name = "Лидия", Surname = "Шапошникова", Age = 21, Gender = Gender.Female, LanguageId = 11 },
                new Employee { Name = "Василиса", Surname = "Сорокина", Age = 21, Gender = Gender.Female, LanguageId = 12 },
                new Employee { Name = "Егор", Surname = "Егоров", Age = 21, Gender = Gender.Male, LanguageId = 13 },
                new Employee { Name = "Иван", Surname = "Некрасов", Age = 21, Gender = Gender.Male, LanguageId = 14 },
                new Employee { Name = "Даниил", Surname = "Савин", Age = 21, Gender = Gender.Male, LanguageId = 15 },
                new Employee { Name = "Лев", Surname = "Гончаров", Age = 21, Gender = Gender.Male, LanguageId = 16 },
                new Employee { Name = "Михаил", Surname = "Иванов", Age = 21, Gender = Gender.Male, LanguageId = 17 },
                new Employee { Name = "Валерия", Surname = "Калмыкова", Age = 21, Gender = Gender.Female, LanguageId = 18 },
                new Employee { Name = "Алексей", Surname = "Соловьев", Age = 21, Gender = Gender.Male, LanguageId = 19 },
                new Employee { Name = "Мадина", Surname = "Белякова", Age = 21, Gender = Gender.Female, LanguageId = 20 },
                new Employee { Name = "Марк", Surname = "Васильев", Age = 21, Gender = Gender.Male, LanguageId = 21 },
                new Employee { Name = "Степан", Surname = "Царев", Age = 21, Gender = Gender.Male, LanguageId = 22 },
                new Employee { Name = "Ульяна", Surname = "Щербакова", Age = 21, Gender = Gender.Female, LanguageId = 23 },
                new Employee { Name = "София", Surname = "Большакова", Age = 21, Gender = Gender.Female, LanguageId = 24 },
                new Employee { Name = "Алёна", Surname = "Касаткина", Age = 21, Gender = Gender.Female, LanguageId = 25 },
                new Employee { Name = "Илья", Surname = "Афанасьев", Age = 21, Gender = Gender.Male, LanguageId = 26 },
                new Employee { Name = "Ева", Surname = "Маркова", Age = 21, Gender = Gender.Female, LanguageId = 27 },
                new Employee { Name = "Артём", Surname = "Комаров", Age = 21, Gender = Gender.Male, LanguageId = 28 },
                new Employee { Name = "Мария", Surname = "Баженова", Age = 21, Gender = Gender.Female, LanguageId = 29 },
                new Employee { Name = "Николай", Surname = "Фомин", Age = 21, Gender = Gender.Male, LanguageId = 30 },
                new Employee { Name = "Елизавета", Surname = "Черкасова", Age = 21, Gender = Gender.Female, LanguageId = 31 },
                new Employee { Name = "Алёна", Surname = "Чумакова", Age = 21, Gender = Gender.Female, LanguageId = 32 },
                new Employee { Name = "Андрей", Surname = "Третьяков", Age = 21, Gender = Gender.Male, LanguageId = 33 },
                new Employee { Name = "Валерия", Surname = "Степанова", Age = 21, Gender = Gender.Female, LanguageId = 34 },
                new Employee { Name = "Эмир", Surname = "Тихонов", Age = 21, Gender = Gender.Male, LanguageId = 35 },
                new Employee { Name = "Ева", Surname = "Николаева", Age = 21, Gender = Gender.Female, LanguageId = 36 },
                new Employee { Name = "Арина", Surname = "Лосева", Age = 21, Gender = Gender.Female, LanguageId = 37 },
                new Employee { Name = "Ксения", Surname = "Филатова", Age = 21, Gender = Gender.Female, LanguageId = 38 },
                new Employee { Name = "Евгений", Surname = "Зверев", Age = 21, Gender = Gender.Male, LanguageId = 39 },
                new Employee { Name = "Лев", Surname = "Карпов", Age = 21, Gender = Gender.Male, LanguageId = 40 }
            };
            RandomizeEmployees(employees);

            context.AddRange(employees);
            context.AddRange(languages);
            context.SaveChanges();
        }

        private void RandomizeEmployees(List<Employee> employees)
        {
            var rnd = new Random();
            foreach (var employee in employees)
            {
                employee.Age = (byte)rnd.Next(18, 40);
                employee.LanguageId = rnd.Next(1, 425);
                employee.Post = (Post)rnd.Next(1, 6);
            }
        }
    }
}
