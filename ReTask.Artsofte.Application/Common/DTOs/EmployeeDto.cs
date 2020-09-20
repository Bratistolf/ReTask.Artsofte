using ReTask.Artsofte.Application.Common.DTOs.Base;
using ReTask.Artsofte.Application.Common.Mappings.Interfaces;
using ReTask.Artsofte.Domain.Entities;
using System.Text.Json.Serialization;

namespace ReTask.Artsofte.Application.Common.DTOs
{
    public class EmployeeDto : BaseDto, IMapFrom<Employee>
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("surname")]
        public string Surname { get; set; }

        [JsonPropertyName("age")]
        public int Age { get; set; }

        [JsonPropertyName("gender")]
        public int Gender { get; set; }
        
        [JsonPropertyName("department_id")]
        public int? DepartmentId { get; set; }

        [JsonPropertyName("language_id")]
        public int? LanguageId { get; set; }
    }
}
