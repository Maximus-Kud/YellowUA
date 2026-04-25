using YellowUA.Core.DTO.Response;
using YellowUA.Core.Models.Products;

namespace YellowUA.Core.Services.Marketplace.Cart
{
    public interface ICartService
    {
        Task<List<CartProduct>> GetCart(string userId);

        Task AddItemToCart(string userId, int productId);

        Task<FlagResponseDTO> RemoveItemFromCart(string userId, int productId);
    }
}
