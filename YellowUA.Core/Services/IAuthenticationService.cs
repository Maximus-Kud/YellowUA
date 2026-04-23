using Microsoft.AspNetCore.Mvc;
using YellowUA.Core.DTO.Authentication;

namespace YellowUA.Core.Services
{
    public interface IAuthenticationService
    {
        Task<ActionResult> Register([FromBody] RegistrationDTO registrationData);

        Task<ActionResult> Login([FromBody] LoginDTO loginData);
    }
}
