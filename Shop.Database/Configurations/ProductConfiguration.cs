using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.Models;

namespace Shop.Database.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        { 
           builder.HasKey(product => product.Id);
           builder.HasIndex(product => product.Id).IsUnique();
           builder.Property(product => product.Title).HasMaxLength(256);
           builder.Property(product => product.Description).HasMaxLength(1024);
        }
    }
}
