using System.Text.Json.Serialization;

namespace ZeroZeroOne.Entities.ZeroOne
{
    public class Client
    {
        [JsonPropertyName("ClienteId")]
        public string ClientId { get; set; } = null!;

        [JsonPropertyName("Nombre")]
        public string Name { get; set; } = null!;
    }
}
