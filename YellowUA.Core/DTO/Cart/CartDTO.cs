using System.ComponentModel.DataAnnotations;

namespace YellowUA.Core.DTO.Cart
{
    public class CartDTO
    {
        [Required]
        public string UserId { get; set; } = string.Empty;

        [Required]
        public int ProductId { get; set; }
    }
}
