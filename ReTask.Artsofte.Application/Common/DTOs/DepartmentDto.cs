using ReTask.Artsofte.Application.Common.DTOs.Base;
using ReTask.Artsofte.Application.Common.Mappings.Interfaces;
using ReTask.Artsofte.Domain.Entities;
using System.Text.Json.Serialization;

namespace ReTask.Artsofte.Application.Common.DTOs
{
    public class DepartmentDto : BaseDto, IMapFrom<Department>
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("floor")]
        public int Floor { get; set; }
    }
}
