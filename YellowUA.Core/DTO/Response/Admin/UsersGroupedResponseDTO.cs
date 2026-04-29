namespace YellowUA.Core.DTO.Response.Admin
{
    public class UsersGroupedResponseDTO
    {
        public List<UserResponseDTO> Customers { get; set; }

        public List<UserResponseDTO> Admins { get; set; }
    }
}
