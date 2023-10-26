using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shop.Application.Interfaces;

namespace Shop.Database
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["DbConnection"];
            
            services.AddDbContext<ShopDbContext>(options =>
            {
                options.UseNpgsql(connectionString);
            });

            services.AddScoped<IShopDbContext>(provider =>
                provider.GetService<ShopDbContext>());

            return services;
        }
    }
}
