using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using YellowUA.Core.Models;
using YellowUA.Core.Models.Products;

namespace YellowUA.Core
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }


        public DbSet<Product> Products { get; set; }

        public DbSet<CartProduct> CartProducts { get; set; }
    }
}
