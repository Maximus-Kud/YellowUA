namespace YellowUA.Core.DTO.Response.Authentication
{
    public class RegistrationResponseDTO
    {
        public bool Success { get; set; }

        public string Response { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;
    }
}
