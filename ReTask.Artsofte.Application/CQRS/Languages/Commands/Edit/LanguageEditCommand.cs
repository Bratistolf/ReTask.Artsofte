using AutoMapper;
using MediatR;
using ReTask.Artsofte.Application.Common.Interfaces;
using ReTask.Artsofte.Domain.Entities;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace ReTask.Artsofte.Application.CQRS.Languages.Commands.Edit
{
    public class LanguageEditCommand : IRequest
    {
        [JsonIgnore]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        public class LanguageEditCommandHandler : IRequestHandler<LanguageEditCommand>
        {
            private readonly IGenericRepository<Language> _languageRepository;

            public LanguageEditCommandHandler(IGenericRepository<Language> languageRepository)
            {
                _languageRepository = languageRepository;
            }

            public async Task<Unit> Handle(LanguageEditCommand request, CancellationToken cancellationToken)
            {
                var lang = await _languageRepository.GetByIdAsync(request.Id);
                lang.Name = request.Name;
                await _languageRepository.UpdateAsync(lang, cancellationToken);
                return new Unit();
            }
        }
    }
}
