using System.Text.Json.Serialization;

namespace ZeroZeroOne.API.ZeroOne.Models
{
    public class Project
    {
        [JsonPropertyName("ProyectoId")]
        public string ProjectId { get; set; } = null!;

        [JsonPropertyName("Nombre")]
        public string Name { get; set; } = null!;
    }
}
