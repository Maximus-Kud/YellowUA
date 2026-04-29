using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using YellowUA.Core.DTO.Admin;
using YellowUA.Core.DTO.Response;
using YellowUA.Core.DTO.Response.Admin;
using YellowUA.Core.Models;
using YellowUA.Core.Models.Products;
using YellowUA.Core.Models.Roles;

namespace YellowUA.Core.Services.Admin
{
    public class AdminService : IAdminService
    {
        private readonly AppDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public AdminService(AppDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }



        public async Task<UsersGroupedResponseDTO> GetAllUsers()
        {
            var customers = await _userManager.GetUsersInRoleAsync(RoleNames.Customer);
            var admins = await _userManager.GetUsersInRoleAsync(RoleNames.Admin);

            var customersResponse = customers.Select(u => new UserResponseDTO { FirstName = u.FirstName, LastName = u.LastName, Email = u.Email, Balance = u.Balance }).ToList();
            var adminsResponse = admins.Select(u => new UserResponseDTO { FirstName = u.FirstName, LastName = u.LastName, Email = u.Email, Balance = u.Balance }).ToList();

            return new UsersGroupedResponseDTO
            {
                Admins = adminsResponse,
                Customers = customersResponse
            };
        }


        public async Task<List<Product>> GetAllProducts()
        {
            return await _context.Products.ToListAsync();
        }


        public async Task<ResponseDTO<Product>> AddProduct(NewProductDTO newProductData)
        {
            if (newProductData.Price <= 0) return new ResponseDTO<Product> { Success = false, Message = "Price can not be 0 or smaller" };

            if (newProductData.InStock <= 0) return new ResponseDTO<Product> { Success = false, Message = "InStock value can not be 0 or smaller " };

            var newProduct = new Product
            {
                Name = newProductData.ProductName,
                Price = newProductData.Price,
                InStock = newProductData.InStock,
                IsAvailable = true,
                Code = newProductData.Code,
            };


            _context.Products.Add(newProduct);
            await _context.SaveChangesAsync();


            return new ResponseDTO<Product>
            {
                Success = true,
                Message = "Created product successful",
                Data = newProduct,
            };
        }


        public async Task<ResponseDTO<Product>> ChangeProduct(int id, ChangeProductDTO changeProductData)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null) return new ResponseDTO<Product> { Success = false, Message = "Product not found" };

            if (changeProductData.Price.HasValue && changeProductData.Price <= 0) return new ResponseDTO<Product> { Success = false, Message = "Price can not be 0 or smaller" };
            if (changeProductData.InStock.HasValue && changeProductData.InStock < 0) return new ResponseDTO<Product> { Success = false, Message = "InStock value can not be negative" };

            bool noNameChange = changeProductData.Name == null || changeProductData.Name == product.Name;

            bool noPriceChange = !changeProductData.Price.HasValue || changeProductData.Price.Value == product.Price;

            bool noStockChange = !changeProductData.InStock.HasValue || changeProductData.InStock.Value == product.InStock;

            bool noAvailabilityChange = !changeProductData.IsAvailable.HasValue || changeProductData.IsAvailable.Value == product.IsAvailable;

            bool noCodeChange = changeProductData.Code == null || changeProductData.Code == product.Code;

            if (noNameChange && noPriceChange && noStockChange && noAvailabilityChange && noCodeChange) return new ResponseDTO<Product> { Success = false, Message = "No changes were made" };

            
            if (!noNameChange) product.Name = changeProductData.Name!;
            if (!noPriceChange) product.Price = changeProductData.Price!.Value;
            if (!noStockChange) product.InStock = changeProductData.InStock!.Value;
            if (!noAvailabilityChange) product.IsAvailable = changeProductData.IsAvailable!.Value;
            if (!noCodeChange) product.Code = changeProductData.Code!;

            if (changeProductData.InStock == 0) product.IsAvailable = false;

            await _context.SaveChangesAsync();


            return new ResponseDTO<Product>
            {
                Success = true,
                Message = $"Product #{id} was successfully changed",
                Data = product
            };
        }


        public async Task<FlagResponseDTO> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null) return new FlagResponseDTO { Success = false, Message = "Product was not found" };

            _context.Products.Remove(product);

            await _context.SaveChangesAsync();


            return new FlagResponseDTO
            {
                Success = true,
                Message = $"Product #{id} was successfully removed from the database"
            };
        }


        public async Task<List<CartProduct>> GetProductsInCart()
        {
            return await _context.CartProducts.ToListAsync();
        }


        public async Task<ResponseDTO<decimal>> ChangeAccountBalance(ChangeBalanceDTO changeBalanceData)
        {
            var user = await _context.Users.FindAsync(changeBalanceData.UserId);
            if (user == null) return new ResponseDTO<decimal> { Success = false, Message = "User not found" };

            if (changeBalanceData.NewBalance < 0) return new ResponseDTO<decimal> { Success = false, Message = "User balance can not be negative" };

            user.Balance = changeBalanceData.NewBalance;

            await _context.SaveChangesAsync();


            return new ResponseDTO<decimal>
            {
                Success = true,
                Message = $"User #{changeBalanceData.UserId}: balance successfully updated",
                Data = user.Balance
            };
        }
    }
}
