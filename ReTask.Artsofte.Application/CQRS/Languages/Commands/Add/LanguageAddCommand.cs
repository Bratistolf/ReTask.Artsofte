using AutoMapper;
using MediatR;
using ReTask.Artsofte.Application.Common.Interfaces;
using ReTask.Artsofte.Application.Common.Mappings.Interfaces;
using ReTask.Artsofte.Domain.Entities;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace ReTask.Artsofte.Application.CQRS.Languages.Commands.Add
{
    public class LanguageAddCommand : IRequest, IMapTo<Language>
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        public class LanguageAddCommandHandler : IRequestHandler<LanguageAddCommand>
        {
            private readonly IGenericRepository<Language> _languageRepository;
            private readonly IMapper _mapper;

            public LanguageAddCommandHandler(IGenericRepository<Language> languageRepository, IMapper mapper)
            {
                _languageRepository = languageRepository;
                _mapper = mapper;
            }

            public async Task<Unit> Handle(LanguageAddCommand request, CancellationToken cancellationToken)
            {
                var newLang = _mapper.Map<Language>(request);
                await _languageRepository.AddAsync(newLang, cancellationToken);
                return new Unit();
            }
        }
    }
}
