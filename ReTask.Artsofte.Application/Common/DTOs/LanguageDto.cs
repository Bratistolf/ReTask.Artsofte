using ReTask.Artsofte.Application.Common.DTOs.Base;
using ReTask.Artsofte.Application.Common.Mappings.Interfaces;
using ReTask.Artsofte.Domain.Entities;
using System.Text.Json.Serialization;

namespace ReTask.Artsofte.Application.Common.DTOs
{
    public class LanguageDto : BaseDto, IMapFrom<Language>
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("color")]
        public string Color { get; set; }
    }
}
