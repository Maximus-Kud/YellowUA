using YellowUA.Core.DTO.Admin;
using YellowUA.Core.DTO.Response;
using YellowUA.Core.DTO.Response.Admin;
using YellowUA.Core.Models;
using YellowUA.Core.Models.Products;

namespace YellowUA.Core.Services.Admin
{
    public interface IAdminService
    {
        Task<UsersGroupedResponseDTO> GetAllUsers();

        Task<List<Product>> GetAllProducts();

        Task<ResponseDTO<Product>> AddProduct(NewProductDTO newProductData);

        Task<ResponseDTO<Product>> ChangeProduct(int id, ChangeProductDTO changeProductData);

        Task<FlagResponseDTO> DeleteProduct(int id);

        Task<List<CartProduct>> GetProductsInCart();

        Task<ResponseDTO<decimal>> ChangeAccountBalance(ChangeBalanceDTO changeBalanceData);
    }
}
