using MediatR;
using ReTask.Artsofte.Application.Common.Interfaces;
using ReTask.Artsofte.Domain.Entities;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace ReTask.Artsofte.Application.CQRS.Departments.Commands.Delete
{
    public class DepartmentDeleteCommand : IRequest
    {
        [JsonIgnore]
        public int Id { get; set; }

        public class DepartmentDeleteCommandHandler : IRequestHandler<DepartmentDeleteCommand>
        {
            private readonly IGenericRepository<Department> _departmentRepository;

            public DepartmentDeleteCommandHandler(IGenericRepository<Department> departmentRepository)
            {
                _departmentRepository = departmentRepository;
            }

            public async Task<Unit> Handle(DepartmentDeleteCommand request, CancellationToken cancellationToken)
            {
                var department = await _departmentRepository.GetByIdAsync(request.Id);
                await _departmentRepository.DeleteAsync(department, cancellationToken);
                return new Unit();
            }
        }
    }
}
