namespace AppSettings.BasicWebAPI.Domain.Entities {
    public class TokenGenerationRequest {
        public string? Email { get; set; }
        public string? UserId { get; set; }
        public Dictionary<string, string>? CustomClaims { get; set; }
    }
}
