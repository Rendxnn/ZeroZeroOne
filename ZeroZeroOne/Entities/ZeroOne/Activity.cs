using System.Text.Json.Serialization;

namespace ZeroZeroOne.Entities.ZeroOne
{
    public class Activity
    {
        [JsonPropertyName("ActividadId")]
        public string ActivityId { get; set; } = null!;

        [JsonPropertyName("Nombre")]
        public string Name { get; set; } = null!;
    }
}
