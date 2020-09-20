using System.Text.Json.Serialization;

namespace ReTask.Artsofte.Application.Common.DTOs.Base
{
    public class BaseDto
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
    }
}
