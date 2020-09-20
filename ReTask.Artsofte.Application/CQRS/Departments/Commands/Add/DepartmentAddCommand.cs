using AutoMapper;
using MediatR;
using ReTask.Artsofte.Application.Common.Interfaces;
using ReTask.Artsofte.Application.Common.Mappings.Interfaces;
using ReTask.Artsofte.Domain.Entities;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace ReTask.Artsofte.Application.CQRS.Departments.Commands.Add
{
    public class DepartmentAddCommand : IRequest, IMapTo<Department>
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("floor")]
        public int Floor { get; set; }

        public class DepartmentAddCommandHandler : IRequestHandler<DepartmentAddCommand>
        {
            private readonly IGenericRepository<Department> _departmentRepository;
            private readonly IMapper _mapper;

            public DepartmentAddCommandHandler(IGenericRepository<Department> departmentRepository, IMapper mapper)
            {
                _departmentRepository = departmentRepository;
                _mapper = mapper;
            }

            public async Task<Unit> Handle(DepartmentAddCommand request, CancellationToken cancellationToken)
            {
                var newDepartment = _mapper.Map<Department>(request);
                await _departmentRepository.AddAsync(newDepartment, cancellationToken);
                return new Unit();
            }
        }
    }
}
