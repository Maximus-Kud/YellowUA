using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using YellowUA.Core.DTO.Response.Marketplace;
using YellowUA.Core.Models;
using YellowUA.Core.Models.Products;

namespace YellowUA.Core.Services.Marketplace
{
    public class MarketplaceService : IMarketplaceService
    {
        private readonly AppDbContext _context;

        public MarketplaceService(AppDbContext context)
        {
            _context = context;
        }



        public async Task<List<Product>> GetAvailableProducts()
        {
            return await _context.Products.Where(p => p.IsAvailable && p.InStock > 0).ToListAsync();
        }
    }
}
