using YellowUA.Core.DTO.Cart;
using YellowUA.Core.DTO.Response;
using YellowUA.Core.Models.Products;

namespace YellowUA.Core.Services.Marketplace.Cart
{
    public interface ICartService
    {
        Task<List<CartProduct>> GetCart(string userId);

        Task AddItemToCart(CartDTO cartData);

        Task<FlagResponseDTO> RemoveItemFromCart(CartDTO cartData);

        Task<FlagResponseDTO> BuyItemsFromCart(string userId);
    }
}
