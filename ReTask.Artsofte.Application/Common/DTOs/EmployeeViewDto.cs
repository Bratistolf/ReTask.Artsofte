using ReTask.Artsofte.Application.Common.DTOs.Base;
using ReTask.Artsofte.Application.Common.Mappings.Interfaces;
using ReTask.Artsofte.Domain.Entities;
using System.Text.Json.Serialization;

namespace ReTask.Artsofte.Application.Common.DTOs
{
    public class EmployeeViewDto : BaseDto, IMapFrom<Employee>
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("surname")]
        public string Surname { get; set; }

        [JsonPropertyName("age")]
        public int Age { get; set; }

        [JsonPropertyName("gender")]
        public string Gender { get; set; }

        [JsonPropertyName("department")]
        public string Department { get; set; }

        [JsonPropertyName("language")]
        public string Language { get; set; }
    }
}
