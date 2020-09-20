using MediatR;
using ReTask.Artsofte.Application.Common.Interfaces;
using ReTask.Artsofte.Domain.Entities;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace ReTask.Artsofte.Application.CQRS.Employees.Commands.Delete
{
    public class EmployeeDeleteCommand : IRequest
    {
        [JsonIgnore]
        public int Id { get; set; }

        public class EmployeeDeleteCommandHandler : IRequestHandler<EmployeeDeleteCommand>
        {
            private readonly IGenericRepository<Employee> _employeeRepository;

            public EmployeeDeleteCommandHandler(IGenericRepository<Employee> employeeRepository)
            {
                _employeeRepository = employeeRepository;
            }

            public async Task<Unit> Handle(EmployeeDeleteCommand request, CancellationToken cancellationToken)
            {
                var employee = await _employeeRepository.GetByIdAsync(request.Id);
                await _employeeRepository.DeleteAsync(employee, cancellationToken);
                return new Unit();
            }
        }
    }
}
