using System.ComponentModel.DataAnnotations;

namespace YellowUA.Core.DTO.Admin
{
    public class ChangeBalanceDTO
    {
        [Required]
        public string UserId { get; set; }

        [Required]
        public decimal NewBalance { get; set; }
    }
}
