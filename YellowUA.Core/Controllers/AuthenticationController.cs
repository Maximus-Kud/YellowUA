using Microsoft.AspNetCore.Mvc;
using YellowUA.Core.DTO.Authentication;
using YellowUA.Core.Services.Authentication;

namespace YellowUA.Core.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }


        [HttpPost("register")]
        public async Task<ActionResult> Register([FromBody] RegistrationDTO registrationData)
        {
            var result = await _authenticationService.Register(registrationData);
            if (!result.Success) return BadRequest(result.Response);

            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] LoginDTO loginData)
        {
            var result = await _authenticationService.Login(loginData);
            if (!result.Success) return Unauthorized(result.Response);

            return Ok(result);
        }
    }
}
