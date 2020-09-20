using MediatR;
using ReTask.Artsofte.Application.Common.Interfaces;
using ReTask.Artsofte.Domain.Entities;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace ReTask.Artsofte.Application.CQRS.Departments.Commands.Edit
{
    public class DepartmentEditCommand : IRequest
    {
        [JsonIgnore]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("floor")]
        public int Floor { get; set; }

        public class DepartmentEditCommandHandler : IRequestHandler<DepartmentEditCommand>
        {
            private readonly IGenericRepository<Department> _departmentRepository;

            public DepartmentEditCommandHandler(IGenericRepository<Department> departmentRepository)
            {
                _departmentRepository = departmentRepository;
            }

            public async Task<Unit> Handle(DepartmentEditCommand request, CancellationToken cancellationToken)
            {
                var department = await _departmentRepository.GetByIdAsync(request.Id);
                department.Name = request.Name;
                department.Floor = request.Floor;
                await _departmentRepository.UpdateAsync(department, cancellationToken);
                return new Unit();
            }
        }
    }
}
