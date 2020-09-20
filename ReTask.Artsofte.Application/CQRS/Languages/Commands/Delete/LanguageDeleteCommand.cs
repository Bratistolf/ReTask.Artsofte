using MediatR;
using ReTask.Artsofte.Application.Common.Interfaces;
using ReTask.Artsofte.Domain.Entities;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace ReTask.Artsofte.Application.CQRS.Languages.Commands.Delete
{
    public class LanguageDeleteCommand : IRequest
    {
        [JsonIgnore]
        public int Id { get; set; }

        public class LanguageDeleteCommandHandler : IRequestHandler<LanguageDeleteCommand>
        {
            private readonly IGenericRepository<Language> _languageRepository;

            public LanguageDeleteCommandHandler(IGenericRepository<Language> languageRepository)
            {
                _languageRepository = languageRepository;
            }

            public async Task<Unit> Handle(LanguageDeleteCommand request, CancellationToken cancellationToken)
            {
                var lang = await _languageRepository.GetByIdAsync(request.Id);
                await _languageRepository.DeleteAsync(lang, cancellationToken);
                return new Unit();
            }
        }
    }
}
