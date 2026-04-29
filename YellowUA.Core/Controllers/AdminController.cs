using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using YellowUA.Core.DTO.Admin;
using YellowUA.Core.Models.Roles;
using YellowUA.Core.Services.Admin;

namespace YellowUA.Core.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }



        [Authorize(Roles = RoleNames.Admin)]
        [HttpGet("getAllUsers")]
        public async Task<ActionResult> GetAllUsers()
        {
            return Ok(await _adminService.GetAllUsers());
        }


        [Authorize(Roles = RoleNames.Admin)]
        [HttpGet("getAllProducts")]
        public async Task<ActionResult> GetAllProducts()
        {
            return Ok(await _adminService.GetAllProducts());
        }


        [Authorize(Roles = RoleNames.Admin)]
        [HttpPost("addProduct")]
        public async Task<ActionResult> AddNewProduct([FromBody] NewProductDTO newProductData)
        {
            if (!ModelState.IsValid) return BadRequest("Invalid input");

            var response = await _adminService.AddProduct(newProductData);
            if (!response.Success) return BadRequest(response.Message);

            return Ok(response);
        }


        [Authorize(Roles = RoleNames.Admin)]
        [HttpPatch("changeProduct")]
        public async Task<ActionResult> ChangeProduct(int id, [FromBody] ChangeProductDTO changeProductData)
        {
            if (!ModelState.IsValid) return BadRequest("Invalid input");

            var response = await _adminService.ChangeProduct(id, changeProductData);
            if (!response.Success) return BadRequest(response.Message);

            return Ok(response);
        }


        [Authorize(Roles = RoleNames.Admin)]
        [HttpDelete("deleteProduct")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            var response = await _adminService.DeleteProduct(id);
            if (response.Success) return BadRequest(response.Message);

            return Ok(response);
        }


        [Authorize(Roles = RoleNames.Admin)]
        [HttpGet("getProductsInCart")]
        public async Task<ActionResult> GetProductsInCart()
        {
            return Ok(await _adminService.GetProductsInCart());
        }


        [Authorize(Roles = RoleNames.Admin)]
        [HttpPatch("changeAccountBalance")]
        public async Task<ActionResult> ChangeAccountBalance([FromBody] ChangeBalanceDTO changeBalanceData)
        {
            if (!ModelState.IsValid) return BadRequest("Invalid input");

            var response = await _adminService.ChangeAccountBalance(changeBalanceData);
            if (response.Success) return BadRequest(response.Message);


            return Ok(response);
        }
    }
}
