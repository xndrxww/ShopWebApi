using Shop.Application.Products.Commands.DeleteProduct;
using Shop.Tests.Common;

namespace Shop.Tests.Commands
{
    public class DeleteProductCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task DeleteProductCommandHandler_Succeess()
        {
            var handler = new DeleteProductCommandHandler(Context);

            await handler.Handle(new DeleteProductCommand
            {
                Id = ShopContextFactory.ProductIdForDelete
            }, CancellationToken.None);

            Assert.Null(Context.Products.SingleOrDefault(product =>
            product.Id == ShopContextFactory.ProductIdForDelete));
        }

        [Fact]
        public async Task DeleteProductCommandHandler_FailOnWrongId()
        {
            var handler = new DeleteProductCommandHandler(Context);

            await Assert.ThrowsAsync<DirectoryNotFoundException>(async () =>
            {
                await handler.Handle(
                    new DeleteProductCommand
                    {
                        Id = Guid.NewGuid()
                    },
                    CancellationToken.None);
            });
        }
    }
}
