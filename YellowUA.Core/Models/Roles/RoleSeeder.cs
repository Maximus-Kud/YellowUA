using Microsoft.AspNetCore.Identity;

namespace YellowUA.Core.Models.Roles
{
    public static class RoleSeeder
    {
        public static async Task SeedAsync(RoleManager<IdentityRole> roleManager)
        {
            if (!await roleManager.RoleExistsAsync(Roles.Customer)) await roleManager.CreateAsync(new IdentityRole(Roles.Customer));

            if (!await roleManager.RoleExistsAsync(Roles.Admin)) await roleManager.CreateAsync(new IdentityRole(Roles.Admin));
        }
    }
}
