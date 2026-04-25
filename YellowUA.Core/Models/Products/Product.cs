using System.ComponentModel.DataAnnotations;

namespace YellowUA.Core.Models.Products
{
    public class Product
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MinLength(5)]
        public string Name { get; set; } = string.Empty;

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int InStock { get; set; }

        [Required]
        public bool IsAvailable { get; set; }
    }
}
