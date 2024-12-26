using System.Text.Json.Serialization;

namespace ZeroZeroOne.Entities.ZeroOne
{
    public class Options
    {
        [JsonPropertyName("Actividades")]
        public List<Activity> Activities { get; set; } = [];

        [JsonPropertyName("Clientes")]
        public List<Client> Clients { get; set; } = [];

        [JsonPropertyName("Proyectos")]
        public List<Project> Projects { get; set; } = [];

    }
}
