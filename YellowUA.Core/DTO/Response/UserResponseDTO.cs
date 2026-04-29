using YellowUA.Core.Models.Roles;

namespace YellowUA.Core.DTO.Response
{
    public class UserResponseDTO
    {
        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public decimal Balance { get; set; }

        public List<string> Roles { get; set; } = new List<string>();
    }
}
