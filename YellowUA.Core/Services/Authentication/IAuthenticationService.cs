using Microsoft.AspNetCore.Mvc;
using YellowUA.Core.DTO.Authentication;
using YellowUA.Core.DTO.Response.Authentication;

namespace YellowUA.Core.Services.Authentication
{
    public interface IAuthenticationService
    {
        Task<RegistrationResponseDTO> Register(RegistrationDTO registrationData);

        Task<LoginResponseDTO> Login(LoginDTO loginData);
    }
}
