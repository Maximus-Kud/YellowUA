using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using YellowUA.Core.DTO.Cart;
using YellowUA.Core.DTO.Response;
using YellowUA.Core.Services.Marketplace.Cart;

namespace YellowUA.Core.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }



        [Authorize]
        [HttpGet]
        public async Task<ActionResult> GetCart()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null) return NotFound("No user ID");

            return Ok(await _cartService.GetCart(userId));
        }


        [Authorize]
        [HttpPost("addItemToCart")]
        public async Task<ActionResult> AddItemToCart([FromBody] CartDTO cartData)
        {
            if (!ModelState.IsValid) return BadRequest("Invalid input");

            await _cartService.AddItemToCart(cartData);

            return Ok("Added product successfully");
        }


        [Authorize]
        [HttpDelete("removeItemFromCart")]
        public async Task<ActionResult> RemoveItemFromCart([FromBody] CartDTO cartData)
        {
            if (!ModelState.IsValid) return BadRequest("Invalid input");

            var result = await _cartService.RemoveItemFromCart(cartData);

            if (!result.Success) return BadRequest("Invalid ID");
            else return Ok("Removed item successfully");
        }


        [Authorize]
        [HttpPost("buyProducts")]
        public async Task<ActionResult> BuyItemsFromCart()
        {
            if (!ModelState.IsValid) return BadRequest("Invalid input");

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null) return NotFound("No user ID");

            var result = await _cartService.BuyItemsFromCart(userId);
            if (!result.Success) return BadRequest(result.Message);

            return Ok("Transaction successful");
        }
    }
}
