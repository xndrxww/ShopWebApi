using Shop.Application.Products.Requests.GetProduct;
using Shop.Database;
using Shouldly;

namespace Shop.Tests.Requests
{
    public class GetProductRequestHandlerTests
    {
        private readonly ShopDbContext _context;

        public GetProductRequestHandlerTests(ShopDbContext context)
        {
            _context = context;
        }

        [Fact]
        public async Task GetProductRequestHandler_Success()
        {
            var handler = new GetProductRequestHandler(_context);

            var result = await handler.Handle(new GetProductRequest
            {
                Id = Guid.Parse("E5F1E0D5-7DB7-4CAD-AC66-575E5C50B7F2")
            }, CancellationToken.None);

            result.Title.ShouldBe("Title for test1");
            result.Description.ShouldBe("Description for test1");
            result.Size.ShouldBe(Domain.Enums.Size.Small);
        }
    }
}
