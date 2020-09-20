using AutoMapper;
using MediatR;
using ReTask.Artsofte.Application.Common.DTOs;
using ReTask.Artsofte.Application.Common.Interfaces;
using ReTask.Artsofte.Domain.Entities;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace ReTask.Artsofte.Application.CQRS.Departments.Queries.GetById
{
    public class DepartmentGetByIdQuery : IRequest<DepartmentDto>
    {
        [JsonIgnore]
        public int Id { get; set; }

        public class DepartmentGetByIdQueryHandler : IRequestHandler<DepartmentGetByIdQuery, DepartmentDto>
        {
            private readonly IGenericRepository<Department> _departmentRepository;
            private readonly IMapper _mapper;

            public DepartmentGetByIdQueryHandler(IGenericRepository<Department> departmentRepository, IMapper mapper)
            {
                _departmentRepository = departmentRepository;
                _mapper = mapper;
            }

            public async Task<DepartmentDto> Handle(DepartmentGetByIdQuery request, CancellationToken cancellationToken)
            {
                var department = await _departmentRepository.GetByIdAsync(request.Id);
                return _mapper.Map<DepartmentDto>(department);
            }
        }
    }
}
