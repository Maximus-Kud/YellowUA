using Microsoft.AspNetCore.Mvc;
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



        [HttpGet]
        public async Task<ActionResult> GetCart([FromBody] string userId)
        {
            return Ok(await _cartService.GetCart(userId));
        }


        [HttpPost("addItemToCart")]
        public async Task<ActionResult> AddItemToCart(string userId, int productId)
        {
            await _cartService.AddItemToCart(userId, productId);

            return Ok("Added product successfully");
        }


        [HttpDelete("removeItemFromCart")]
        public async Task<ActionResult> RemoveItemFromCart(string userId, int productId)
        {
            var result = await _cartService.RemoveItemFromCart(userId, productId);

            if (!result.Success) return BadRequest("Invalid ID");
            else return Ok("Removed item successfully");
        }
    }
}
