using MediatR;
using ReTask.Artsofte.Application.Common.DTOs;
using ReTask.Artsofte.Application.Common.Interfaces;
using ReTask.Artsofte.Common;
using ReTask.Artsofte.Domain.Entities;
using ReTask.Artsofte.Domain.Enums;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ReTask.Artsofte.Application.CQRS.Employees.Queries.GetAll
{
    public class EmployeesGetAllQuery : IRequest<IEnumerable<EmployeeListDto>>
    {
        public class EmployeesGetAllQueryHandler : IRequestHandler<EmployeesGetAllQuery, IEnumerable<EmployeeListDto>>
        {
            private readonly IGenericRepository<Employee> _employeeRepository;

            public EmployeesGetAllQueryHandler(IGenericRepository<Employee> employeeRepository)
            {
                _employeeRepository = employeeRepository;
            }

            public async Task<IEnumerable<EmployeeListDto>> Handle(EmployeesGetAllQuery request, CancellationToken cancellationToken)
            {
                var list = await _employeeRepository.GetAllAsync();
                return list.Select(employee => new EmployeeListDto
                {
                    Id = employee.Id,
                    Name = employee.Name,
                    Surname = employee.Surname,
                    Age = employee.Age,
                    Gender = employee.Gender.GetStringValue(),
                    Post = employee.Post.GetStringValue(),
                    Department = employee.Department?.Name ?? string.Empty,
                    Language = employee.Language?.Name ?? string.Empty,
                    LanguageColor = employee.Language?.Color ?? string.Empty
                });
            }
        }
    }
}
