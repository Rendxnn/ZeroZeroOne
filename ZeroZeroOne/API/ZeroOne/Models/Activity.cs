using System.Text.Json.Serialization;

namespace ZeroZeroOne.API.ZeroOne.Models
{
    public class Activity
    {
        [JsonPropertyName("ActividadId")]
        public string ActivityId { get; set; } = null!;

        [JsonPropertyName("Nombre")]
        public string Name { get; set; } = null!;
    }
}
