using Microsoft.AspNetCore.Identity;

namespace YellowUA.Core.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public decimal Balance { get; set; }
    }
}
