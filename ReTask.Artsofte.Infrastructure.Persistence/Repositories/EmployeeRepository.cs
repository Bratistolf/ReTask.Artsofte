using Microsoft.EntityFrameworkCore;
using ReTask.Artsofte.Application.Common.Interfaces;
using ReTask.Artsofte.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReTask.Artsofte.Infrastructure.Persistence.Repositories
{
    public class EmployeeRepository : GenericRepository<Employee>
    {
        public EmployeeRepository(IArtsofteDbContext artsofteDbContext) : base(artsofteDbContext)
        {
        }

        public override async Task<IEnumerable<Employee>> GetAllAsync()
        {
            return await _artsofteDbContext.Set<Employee>()
                .Select(e => new Employee
                {
                    Id = e.Id,
                    Name = e.Name,
                    Surname = e.Surname,
                    Age = e.Age,
                    Gender = e.Gender,
                    Department = e.Department,
                    Language = e.Language
                })
                .ToListAsync();
        }
    }
}
