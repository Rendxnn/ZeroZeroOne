using System.Text.Json.Serialization;

namespace ZeroZeroOne.Entities.ZeroOne
{
    public class Project
    {
        [JsonPropertyName("ProyectoId")]
        public string ProjectId { get; set; } = null!;

        [JsonPropertyName("Nombre")]
        public string Name { get; set; } = null!;
    }
}
