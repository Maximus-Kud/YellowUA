using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using YellowUA.Core.DTO.Response;
using YellowUA.Core.DTO.Response.Marketplace;
using YellowUA.Core.Models;
using YellowUA.Core.Models.Products;

namespace YellowUA.Core.Services.Marketplace
{
    public class MarketplaceService : IMarketplaceService
    {
        private readonly AppDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public MarketplaceService(AppDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }



        public async Task<List<Product>> GetAvailableProducts()
        {
            return await _context.Products.Where(p => p.IsAvailable && p.InStock > 0).ToListAsync();
        }


        public async Task<UserResponseDTO> GetAccountInfo(string userId)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user == null) return null;

            var roles = await _userManager.GetRolesAsync(user);


            return new UserResponseDTO
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Balance = user.Balance,
                Roles = roles.ToList()
            };
        }
    }
}
