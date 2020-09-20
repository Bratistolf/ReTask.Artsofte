using AutoMapper;
using MediatR;
using ReTask.Artsofte.Application.Common.DTOs;
using ReTask.Artsofte.Application.Common.Interfaces;
using ReTask.Artsofte.Domain.Entities;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace ReTask.Artsofte.Application.CQRS.Languages.Queries.GetById
{
    public class LanguageGetByIdQuery : IRequest<LanguageDto>
    {
        [JsonIgnore]
        public int Id { get; set; }

        public class LanguageGetByIdQueryHandler : IRequestHandler<LanguageGetByIdQuery, LanguageDto>
        {
            private readonly IGenericRepository<Language> _languageRepository;
            private readonly IMapper _mapper;

            public LanguageGetByIdQueryHandler(IGenericRepository<Language> languageRepository, IMapper mapper)
            {
                _languageRepository = languageRepository;
                _mapper = mapper;
            }

            public async Task<LanguageDto> Handle(LanguageGetByIdQuery request, CancellationToken cancellationToken)
            {
                var lang = await _languageRepository.GetByIdAsync(request.Id);
                return _mapper.Map<LanguageDto>(lang);
            }
        }
    }
}
