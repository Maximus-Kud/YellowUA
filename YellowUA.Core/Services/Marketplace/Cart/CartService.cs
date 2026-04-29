using Microsoft.EntityFrameworkCore;
using YellowUA.Core.DTO.Cart;
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


        public async Task AddItemToCart(CartDTO cartData)
        {
            var item = await _context.CartProducts.FirstOrDefaultAsync(x => x.UserId == cartData.UserId && x.ProductId == cartData.ProductId);

            if (item != null)
            {
                item.Quantity++;
            }
            else
            {
                _context.CartProducts.Add(new CartProduct
                {
                    UserId = cartData.UserId,
                    ProductId = cartData.ProductId,
                    Quantity = 1
                });
            }

            await _context.SaveChangesAsync();
        }


        public async Task<FlagResponseDTO> RemoveItemFromCart(CartDTO cartData)
        {
            var item = await _context.CartProducts.FirstOrDefaultAsync(x => x.UserId == cartData.UserId && x.ProductId == cartData.ProductId);
            if (item == null) return new FlagResponseDTO { Success = false };

            _context.CartProducts.Remove(item);
            await _context.SaveChangesAsync();

            return new FlagResponseDTO
            {
                Success = true,
            };
        }


        public async Task<FlagResponseDTO> BuyItemsFromCart(string userId)
        {
            await using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == userId);
                if (user == null) return new FlagResponseDTO { Success = false, Message = "User not found" };

                var items = await _context.CartProducts.Include(x => x.Product).Where(x => x.UserId == userId).ToListAsync();
                if (items.Count == 0) return new FlagResponseDTO { Success = false, Message = "No products in cart" };


                decimal total = 0;

                foreach (var item in items)
                {
                    if (item.Product.InStock < item.Quantity) return new FlagResponseDTO { Success = false, Message = $"Not enough stock for {item.Product.Name}" };

                    total += item.Product.Price * item.Quantity;
                    item.Product.InStock -= item.Quantity;

                    if (item.Product.InStock == 0) item.Product.IsAvailable = false;
                }

                if (total > user.Balance) return new FlagResponseDTO { Success = false, Message = "Not enough money" };

                user.Balance -= total;


                _context.CartProducts.RemoveRange(items);

                await _context.SaveChangesAsync();
                await transaction.CommitAsync();

                return new FlagResponseDTO { Success = true };
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                return new FlagResponseDTO { Success = false, Message = "Transaction failed: " + ex };
            }
        }
    }
}
