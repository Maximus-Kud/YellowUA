using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using YellowUA.Core.DTO.Authentication;
using YellowUA.Core.DTO.Response;
using YellowUA.Core.Models;
using YellowUA.Core.Models.Roles;

namespace YellowUA.Core.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public AuthenticationService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }


        public async Task<AuthResponseDTO> Register(RegistrationDTO registrationData)
        {
            var user = new ApplicationUser
            {
                FirstName = registrationData.FirtsName,
                LastName = registrationData.LastName,
                UserName = registrationData.Email,
                Email = registrationData.Email,
            };

            var userFull = await _userManager.CreateAsync(user, registrationData.Password);
            if (!userFull.Succeeded) return new AuthResponseDTO { Error = string.Join(", " + userFull.Errors.Select(e => e.Description)) };

            if (registrationData.Email == "admin@email.com") await _userManager.AddToRoleAsync(user, Roles.Admin);
            else await _userManager.AddToRoleAsync(user, Roles.Customer);


            return new AuthResponseDTO
            {
                Email = user.Email,
                Token = "ffff"
            };
        }



        public async Task<>
    }
}
