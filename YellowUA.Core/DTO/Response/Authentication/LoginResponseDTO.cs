namespace YellowUA.Core.DTO.Response.Authentication
{
    public class LoginResponseDTO
    {
        public bool Success { get; set; }

        public string Response { get; set; } = string.Empty;

        public string Token { get; set; } = string.Empty;
    }
}
