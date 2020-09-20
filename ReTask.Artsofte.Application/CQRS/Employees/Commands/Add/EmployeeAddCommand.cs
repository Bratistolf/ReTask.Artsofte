using AutoMapper;
using MediatR;
using ReTask.Artsofte.Application.Common.Interfaces;
using ReTask.Artsofte.Application.Common.Mappings.Interfaces;
using ReTask.Artsofte.Domain.Entities;
using ReTask.Artsofte.Domain.Enums;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace ReTask.Artsofte.Application.CQRS.Employees.Commands.Add
{
    public class EmployeeAddCommand : IRequest, IMapTo<Employee>
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("surname")]
        public string Surname { get; set; }

        [JsonPropertyName("age")]
        public int Age { get; set; }

        [JsonPropertyName("gender")]
        public Gender Gender { get; set; }

        [JsonPropertyName("department_id")]
        public int? DepartmentId { get; set; }

        [JsonPropertyName("language_id")]
        public int? LanguageId { get; set; }

        public class EmployeeAddCommandHandler : IRequestHandler<EmployeeAddCommand>
        {
            private readonly IGenericRepository<Employee> _artsofteDbContext;
            private readonly IMapper _mapper;

            public EmployeeAddCommandHandler(IGenericRepository<Employee> artsofteDbContext, IMapper mapper)
            {
                _artsofteDbContext = artsofteDbContext;
                _mapper = mapper;
            }

            public async Task<Unit> Handle(EmployeeAddCommand request, CancellationToken cancellationToken)
            {
                var newEmployee = _mapper.Map<Employee>(request);
                await _artsofteDbContext.AddAsync(newEmployee, cancellationToken);
                return new Unit();
            }
        }
    }
}
