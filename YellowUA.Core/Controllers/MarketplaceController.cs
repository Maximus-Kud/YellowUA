using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using YellowUA.Core.DTO.Response.Marketplace;
using YellowUA.Core.Models;
using YellowUA.Core.Services.Marketplace;

namespace YellowUA.Core.Controllers
{
    [ApiController]
    [Route("yellowUA/[Controller]")]
    public class MarketplaceController : ControllerBase
    {
        private readonly IMarketplaceService _marketplaceService;
        private readonly UserManager<ApplicationUser> _userManager;

        public MarketplaceController(IMarketplaceService marketplaceService, UserManager<ApplicationUser> userManager)
        {
            _marketplaceService = marketplaceService;
            _userManager = userManager;
        }



        [HttpGet("getProducts")]
        public async Task<ActionResult> GetAvailableProducts()
        {
            var products = await _marketplaceService.GetAvailableProducts();
            return Ok(products);
        }


        [Authorize]
        [HttpGet("getAccountInfo")]
        public async Task<ActionResult> GetAccountInfo()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null) return NotFound("User was not found");

            return Ok(new
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Balance = user.Balance,
                Role = User.FindFirstValue(ClaimTypes.Role)
            });
        }
    }
}
