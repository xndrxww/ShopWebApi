using Microsoft.EntityFrameworkCore;
using Shop.Application.Common.Exceptions;
using Shop.Application.Products.Commands.UpdateProduct;
using Shop.Domain.Enums;
using Shop.Tests.Common;

namespace Shop.Tests.Commands
{
    public class UpdateProductCommandHandlerTests : TestBase
    {
        [Fact]
        public async Task UpdateProductCommandHandler_Success()
        {
            var handler = new UpdateProductCommandHandler(Context);
            var title = "new title";
            var description = "new description";
            var size = Size.Small;
            ushort quantity = 12;


            await handler.Handle(new UpdateProductCommand
            {
                Id = ShopContextFactory.ProductIdForUpdate,
                Title = title,
                Description = description,
                Size = size,
                Quantity = quantity
            }, CancellationToken.None);

            Assert.NotNull(await Context.Products.SingleOrDefaultAsync(product =>
                product.Id == ShopContextFactory.ProductIdForUpdate &&
                product.Title == title));
        }

        [Fact]
        public async Task UpdateProductCommandHandler_FailOnWrongId()
        {
            var handler = new UpdateProductCommandHandler(Context);

            await Assert.ThrowsAsync<NotFoundException>(async () =>
            {
                await handler.Handle(
                    new UpdateProductCommand
                    {
                        Id = Guid.NewGuid()
                    }, CancellationToken.None);
            });
        }
    }
}
