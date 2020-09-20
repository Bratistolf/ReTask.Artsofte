using AutoMapper;
using MediatR;
using ReTask.Artsofte.Application.Common.Interfaces;
using ReTask.Artsofte.Application.Common.Mappings.Interfaces;
using ReTask.Artsofte.Domain.Entities;
using ReTask.Artsofte.Domain.Enums;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace ReTask.Artsofte.Application.CQRS.Employees.Commands.Edit
{
    public class EmployeeEditCommand : IRequest, IMapTo<Employee>, IHaveCustomMappings
    {
        [JsonIgnore]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("surname")]
        public string Surname { get; set; }

        [JsonPropertyName("age")]
        public int Age { get; set; }

        [JsonPropertyName("gender")]
        public Gender Gender { get; set; }

        [JsonPropertyName("department_id")]
        public int DepartmentId { get; set; }

        [JsonPropertyName("language_id")]
        public int LanguageId { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<EmployeeEditCommand, Employee>()
                .ForMember(x => x.Id, p => p.Ignore());
        }

        public class EmployeeEditCommandHandler : IRequestHandler<EmployeeEditCommand>
        {
            private readonly IGenericRepository<Employee> _employeeRepository;
            private readonly IMapper _mapper;

            public EmployeeEditCommandHandler(IGenericRepository<Employee> employeeRepository, IMapper mapper)
            {
                _employeeRepository = employeeRepository;
                _mapper = mapper;
            }
            
            public async Task<Unit> Handle(EmployeeEditCommand request, CancellationToken cancellationToken)
            {
                var employee = await _employeeRepository.GetByIdAsync(request.Id);
                _mapper.Map(request, employee);
                await _employeeRepository.UpdateAsync(employee, cancellationToken);
                return new Unit();
            }
        }
    }
}
