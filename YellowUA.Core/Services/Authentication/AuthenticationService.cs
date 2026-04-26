using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using YellowUA.Core.DTO.Authentication;
using YellowUA.Core.DTO.Response.Authentication;
using YellowUA.Core.Models;
using YellowUA.Core.Models.Roles;

namespace YellowUA.Core.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;

        public AuthenticationService(UserManager<ApplicationUser> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }



        public async Task<RegistrationResponseDTO> Register(RegistrationDTO registrationData)
        {
            var user = new ApplicationUser
            {
                FirstName = registrationData.FirstName,
                LastName = registrationData.LastName,
                UserName = registrationData.Email,
                Email = registrationData.Email,
            };

            var userFull = await _userManager.CreateAsync(user, registrationData.Password);
            if (!userFull.Succeeded) return new RegistrationResponseDTO { Success = false, Response = string.Join(", ", userFull.Errors.Select(e => e.Description)) };

            if (registrationData.Email == "admin@email.com") await _userManager.AddToRoleAsync(user, Roles.Admin);
            else await _userManager.AddToRoleAsync(user, Roles.Customer);


            return new RegistrationResponseDTO
            {
                Success = true,
                Response = "User created",
                Email = user.Email,
            };
        }


        public async Task<LoginResponseDTO> Login(LoginDTO loginData)
        {
            var user = await _userManager.FindByEmailAsync(loginData.Email);
            if (user == null) return new LoginResponseDTO { Success = false, Response = "Could not find user" };

            var validPassword = await _userManager.CheckPasswordAsync(user, loginData.Password);
            if (!validPassword) return new LoginResponseDTO { Success = false, Response = "Invalid password" };

            var roles = await _userManager.GetRolesAsync(user);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Name, user.UserName!),
                new Claim(ClaimTypes.Email, user.Email!),
            };

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }


            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
            );


            return new LoginResponseDTO
            {
                Success = true,
                Response = "Logged in successfully",
                Token = new JwtSecurityTokenHandler().WriteToken(token)
            };
        }
    }
}
