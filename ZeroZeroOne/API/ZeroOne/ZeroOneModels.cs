using System.Text.Json.Serialization;

namespace ZeroZeroOne.API.ZeroOne
{
    public class ZeroOneModels
    {
        public record LoginRequest
        {
            public string Email { get; set; } = null!;
            public string Password { get; set; } = null!;

            [JsonPropertyName("empresaId")]
            public string CompanyId { get; set; } = null!;
        }

        public record LoginResponse
        {
            [JsonPropertyName("message")]
            public string? Message { get; set; }

            [JsonPropertyName("token")]
            public string? Token { get; set; }

            [JsonPropertyName("userName")]
            public string? Username { get; set; }
        }
    }
}
