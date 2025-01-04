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
            public string? Message { get; set; }
            public string? Token { get; set; }
            public string? Username { get; set; }
        }
    }
}
