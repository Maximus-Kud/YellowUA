using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using YellowUA.Core.Models;

namespace YellowUA.Core
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        //DbSet<ApplicationUser> Addresses { get; set; }
    }
}
