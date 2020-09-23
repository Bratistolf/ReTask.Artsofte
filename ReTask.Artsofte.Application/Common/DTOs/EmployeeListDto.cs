using ReTask.Artsofte.Application.Common.DTOs.Base;
using ReTask.Artsofte.Application.Common.Mappings.Interfaces;
using ReTask.Artsofte.Domain.Entities;
using System.Text.Json.Serialization;

namespace ReTask.Artsofte.Application.Common.DTOs
{
    public class EmployeeListDto : BaseDto, IMapFrom<Employee>
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("surname")]
        public string Surname { get; set; }

        [JsonPropertyName("age")]
        public int Age { get; set; }

        [JsonPropertyName("gender")]
        public string Gender { get; set; }

        [JsonPropertyName("post")]
        public string Post { get; set; }

        [JsonPropertyName("department")]
        public string Department { get; set; }

        [JsonPropertyName("language")]
        public string Language { get; set; }

        [JsonPropertyName("language_color")]
        public string LanguageColor { get; set; }
    }
}
