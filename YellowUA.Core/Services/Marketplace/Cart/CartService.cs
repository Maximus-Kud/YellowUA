using Microsoft.EntityFrameworkCore;
using YellowUA.Core.DTO.Response;
using YellowUA.Core.Models.Products;

namespace YellowUA.Core.Services.Marketplace.Cart
{
    public class CartService : ICartService
    {
        private readonly AppDbContext _context;

        public CartService(AppDbContext context)
        {
            _context = context;
        }


        public async Task<List<CartProduct>> GetCart(string userId)
        {
            return await _context.CartProducts.Include(x => x.Product).Where(x => x.UserId == userId).ToListAsync();
        }

        public async Task AddItemToCart(string userId, int productId)
        {
            var item = await _context.CartProducts.FirstOrDefaultAsync(x => x.UserId == userId && x.ProductId == productId);

            if (item != null)
            {
                item.Quantity++;
            }
            else
            {
                _context.CartProducts.Add(new CartProduct
                {
                    UserId = userId,
                    ProductId = productId,
                    Quantity = 1
                });
            }

            await _context.SaveChangesAsync();
        }

        public async Task<FlagResponseDTO> RemoveItemFromCart(string userId, int productId)
        {
            var item = await _context.CartProducts.FirstOrDefaultAsync(x => x.UserId == userId && x.ProductId == productId);
            if (item == null) return new FlagResponseDTO { Success = false };

            _context.CartProducts.Remove(item);
            await _context.SaveChangesAsync();

            return new FlagResponseDTO
            {
                Success = true,
            };
        }
    }
}
