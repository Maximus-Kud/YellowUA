using YellowUA.Core.DTO.Response;
using YellowUA.Core.DTO.Response.Marketplace;
using YellowUA.Core.Models.Products;

namespace YellowUA.Core.Services.Marketplace
{
    public interface IMarketplaceService
    {
        Task<List<Product>> GetAvailableProducts();

        Task<UserResponseDTO> GetAccountInfo(string userId);
    }
}
