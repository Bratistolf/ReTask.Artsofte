using AutoMapper;
using MediatR;
using ReTask.Artsofte.Application.Common.DTOs;
using ReTask.Artsofte.Application.Common.Interfaces;
using ReTask.Artsofte.Domain.Entities;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace ReTask.Artsofte.Application.CQRS.Employees.Queries.GetById
{
    public class EmployeeGetByIdQuery : IRequest<EmployeeDto>
    {
        [JsonIgnore]
        public int Id { get; set; }

        public class EmployeeGetByIdQueryHandler : IRequestHandler<EmployeeGetByIdQuery, EmployeeDto>
        {
            private readonly IGenericRepository<Employee> _artsofteDbContext;
            private readonly IMapper _mapper;

            public EmployeeGetByIdQueryHandler(IGenericRepository<Employee> artsofteDbContext, IMapper mapper)
            {
                _artsofteDbContext = artsofteDbContext;
                _mapper = mapper;
            }

            public async Task<EmployeeDto> Handle(EmployeeGetByIdQuery request, CancellationToken cancellationToken)
            {
                var lang = await _artsofteDbContext.GetByIdAsync(request.Id);
                return _mapper.Map<EmployeeDto>(lang);
            }
        }
    }
}
