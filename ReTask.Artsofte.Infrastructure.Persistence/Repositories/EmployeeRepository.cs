using Microsoft.EntityFrameworkCore;
using ReTask.Artsofte.Application.Common.Interfaces;
using ReTask.Artsofte.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
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
                .Select(employee => new Employee
                {
                    Id = employee.Id,
                    Name = employee.Name,
                    Surname = employee.Surname,
                    Age = employee.Age,
                    Gender = employee.Gender,
                    Post = employee.Post,
                    Department = employee.Department,
                    Language = employee.Language
                })
                .ToListAsync();
        }
    }
}
