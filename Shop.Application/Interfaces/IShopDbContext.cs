using Microsoft.EntityFrameworkCore;
using Shop.Domain.Models;

namespace Shop.Application.Interfaces
{
    public interface IShopDbContext
    {
        DbSet<Product> Products { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
