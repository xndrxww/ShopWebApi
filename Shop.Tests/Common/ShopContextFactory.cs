using Microsoft.EntityFrameworkCore;
using Shop.Database;
using Shop.Domain.Models;

namespace Shop.Tests.Common
{
    public class ShopContextFactory
    {
        public static Guid ProductIdForDelete = Guid.NewGuid();
        public static Guid ProductIdForUpdate = Guid.NewGuid();

        public static ShopDbContext Create()
        {
            var options = new DbContextOptionsBuilder<ShopDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var context = new ShopDbContext(options);
            context.Database.EnsureCreated();
            context.Products.AddRange(
                new Product
                {
                    Id = Guid.Parse("E5F1E0D5-7DB7-4CAD-AC66-575E5C50B7F2"),
                    Description = "Description for test1",
                    Quantity = 1,
                    Size = Domain.Enums.Size.Small,
                    Title = "Title for test1"
                },
                new Product
                {
                    Id = Guid.Parse("4F9EE5AF-F73F-4B46-AE94-D15EA433FE14"),
                    Description = "Description for test2",
                    Quantity = 2,
                    Size = Domain.Enums.Size.Medium,
                    Title = "Title for test2"
                },
                new Product
                {
                    Id = Guid.Parse("5E3B1341-303F-48A1-AE38-602DFF68F474"),
                    Description = "Description for test3",
                    Quantity = 3,
                    Size = Domain.Enums.Size.Large,
                    Title = "Title for test3"
                },
                new Product
                {
                    Id = Guid.Parse("8610401B-6FC9-4C90-8C39-0535C8422EBC"),
                    Description = "Description for test4",
                    Quantity = 4,
                    Size = Domain.Enums.Size.ExtraLarge,
                    Title = "Title for test4"
                }
                );

            context.SaveChanges();
            return context;
        }

        public static void Destroy(ShopDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}
