using Microsoft.EntityFrameworkCore;
using Shop.Application.Interfaces;
using Shop.Database.Configurations;
using Shop.Domain.Models;

namespace Shop.Database
{
    public class ShopDbContext : DbContext, IShopDbContext
    {
        public DbSet<Product> Products { get; set; }

        public ShopDbContext(DbContextOptions<ShopDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ProductConfiguration());
            base.OnModelCreating(builder);
        }
    }
}
