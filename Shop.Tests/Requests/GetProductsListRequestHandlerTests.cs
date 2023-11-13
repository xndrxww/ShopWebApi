using Shop.Application.Products.Requests;
using Shop.Database;
using Shouldly;

namespace Shop.Tests.Requests
{
    public class GetProductsListRequestHandlerTests
    {
        private readonly ShopDbContext _context;

        public GetProductsListRequestHandlerTests(ShopDbContext context)
        {
            _context = context;
        }

        [Fact]
        public async void GetProductsListRequestHandler_Success()
        {
            var handler = new GetProductsListRequestHandler(_context);

            var result = await handler.Handle(new GetProductsListRequest(), CancellationToken.None);

            result.Count.ShouldBe(2);
        }
    }
}
