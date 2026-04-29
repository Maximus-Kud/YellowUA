using System.ComponentModel.DataAnnotations;

namespace YellowUA.Core.DTO.Admin
{
    public class NewProductDTO
    {
        [Required]
        [MinLength(5)]
        public string ProductName { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int InStock { get; set; }

        [Required]
        public string Code { get; set; }
    }
}
