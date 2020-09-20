using AutoMapper;
using MediatR;
using ReTask.Artsofte.Application.Common.DTOs;
using ReTask.Artsofte.Application.Common.Interfaces;
using ReTask.Artsofte.Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ReTask.Artsofte.Application.CQRS.Departments.Queries.GetAll
{
    public class DepartmentsGetAllQuery : IRequest<IEnumerable<DepartmentDto>>
    {
        public class GetAllQueryHandler : IRequestHandler<DepartmentsGetAllQuery, IEnumerable<DepartmentDto>>
        {
            private readonly IGenericRepository<Department> _departmentRepository;
            private readonly IMapper _mapper;

            public GetAllQueryHandler(IGenericRepository<Department> departmentRepository, IMapper mapper)
            {
                _departmentRepository = departmentRepository;
                _mapper = mapper;
            }

            public async Task<IEnumerable<DepartmentDto>> Handle(DepartmentsGetAllQuery request, CancellationToken cancellationToken)
            {
                var departments = await _departmentRepository.GetAllAsync(); 
                return _mapper.Map<IEnumerable<DepartmentDto>>(departments);
            }
        }
    }
}
