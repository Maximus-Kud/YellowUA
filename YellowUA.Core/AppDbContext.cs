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



        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "Laptop",
                    Price = 1300,
                    InStock = 20,
                    IsAvailable = true,
                },

                new Product
                {
                    Id = 2,
                    Name = "Iphone",
                    Price = 900,
                    InStock = 50,
                    IsAvailable = true,
                },

                new Product
                {
                    Id = 3,
                    Name = "PC",
                    Price = 200,
                    InStock = 10,
                    IsAvailable = true,
                }
            );
        }
    }
}
