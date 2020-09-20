using MediatR;
using ReTask.Artsofte.Application.Common.DTOs;
using ReTask.Artsofte.Application.Common.Interfaces;
using ReTask.Artsofte.Domain.Entities;
using ReTask.Artsofte.Domain.Enums;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ReTask.Artsofte.Application.CQRS.Employees.Queries.GetAll
{
    public class EmployeesGetAllQuery : IRequest<IEnumerable<EmployeeViewDto>>
    {
        public class EmployeesGetAllQueryHandler : IRequestHandler<EmployeesGetAllQuery, IEnumerable<EmployeeViewDto>>
        {
            private readonly IGenericRepository<Employee> _employeeRepository;

            public EmployeesGetAllQueryHandler(IGenericRepository<Employee> employeeRepository)
            {
                _employeeRepository = employeeRepository;
            }

            public async Task<IEnumerable<EmployeeViewDto>> Handle(EmployeesGetAllQuery request, CancellationToken cancellationToken)
            {
                var list = await _employeeRepository.GetAllAsync();
                return list.Select(employee => new EmployeeViewDto
                {
                    Id = employee.Id,
                    Name = employee.Name,
                    Surname = employee.Surname,
                    Age = employee.Age,
                    Gender = employee.Gender == Gender.Male ? "Мужской" : employee.Gender == Gender.Female ? "Женский" : string.Empty,
                    Department = employee.Department?.Name ?? string.Empty,
                    Language = employee.Language?.Name ?? string.Empty
                });
            }
        }
    }
}
