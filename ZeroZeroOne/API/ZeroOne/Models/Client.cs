using System.Text.Json.Serialization;

namespace ZeroZeroOne.API.ZeroOne.Models
{
    public class Client
    {
        [JsonPropertyName("ClienteId")]
        public string ClientId { get; set; } = null!;

        [JsonPropertyName("Nombre")]
        public string Name { get; set; } = null!;
    }
}
