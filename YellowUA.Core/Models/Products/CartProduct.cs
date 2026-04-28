using System.ComponentModel.DataAnnotations;

namespace YellowUA.Core.Models.Products
{
    public class CartProduct
    {
        [Key]
        public int Id { get; set; }

        public string UserId { get; set; } = string.Empty;
        public ApplicationUser User { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int Quantity { get; set; }
    }
}
