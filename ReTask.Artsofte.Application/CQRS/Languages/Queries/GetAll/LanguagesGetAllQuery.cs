using AutoMapper;
using MediatR;
using ReTask.Artsofte.Application.Common.DTOs;
using ReTask.Artsofte.Application.Common.Interfaces;
using ReTask.Artsofte.Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ReTask.Artsofte.Application.CQRS.Languages.Queries.GetAll
{
    public class LanguagesGetAllQuery : IRequest<IEnumerable<LanguageDto>>
    {
        public class LanguagesGetAllQueryHandler : IRequestHandler<LanguagesGetAllQuery, IEnumerable<LanguageDto>>
        {
            private readonly IGenericRepository<Language> _languageRepository;
            private readonly IMapper _mapper;

            public LanguagesGetAllQueryHandler(IGenericRepository<Language> languageRepository, IMapper mapper)
            {
                _languageRepository = languageRepository;
                _mapper = mapper;
            }

            public async Task<IEnumerable<LanguageDto>> Handle(LanguagesGetAllQuery request, CancellationToken cancellationToken)
            {
                var list = await _languageRepository.GetAllAsync();
                return _mapper.Map<IEnumerable<LanguageDto>>(list);
            }
        }
    }
}
