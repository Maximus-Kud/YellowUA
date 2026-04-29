using Microsoft.AspNetCore.Identity;

namespace YellowUA.Core.Models.Roles
{
    public static class RoleSeeder
    {
        public static async Task SeedAsync(RoleManager<IdentityRole> roleManager)
        {
            if (!await roleManager.RoleExistsAsync(RoleNames.Customer)) await roleManager.CreateAsync(new IdentityRole(RoleNames.Customer));

            if (!await roleManager.RoleExistsAsync(RoleNames.Admin)) await roleManager.CreateAsync(new IdentityRole(RoleNames.Admin));
        }
    }
}
