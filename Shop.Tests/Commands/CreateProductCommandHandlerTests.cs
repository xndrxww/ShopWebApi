using Microsoft.EntityFrameworkCore;
using Shop.Application.Products.Commands.CreateProduct;
using Shop.Tests.Common;

namespace Shop.Tests.Commands
{
    public class CreateProductCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task CreateProductCommandHandler_Success()
        {
            var handler = new CreateProductCommandHandler(Context);
            var title = "Title";
            var description = "Description";
            var quantity = 1;
            var size = Domain.Enums.Size.Large;

            var productId = await handler.Handle(
                new CreateProductCommand
                {
                    Title = "title",
                    Description = "description",
                    Quantity = 1,
                    Size = Domain.Enums.Size.Large
                }, CancellationToken.None);

            Assert.NotNull(await Context.Products.SingleOrDefaultAsync(product
                => product.Id == productId && 
                   product.Title == title &&
                   product.Description == description && 
                   product.Quantity == quantity &&
                   product.Size == size));
        }
    }
}
