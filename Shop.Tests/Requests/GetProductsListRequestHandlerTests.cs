using Shop.Application.Products.Requests;
using Shop.Tests.Common;
using Shouldly;

namespace Shop.Tests.Requests
{
    public class GetProductsListRequestHandlerTests : TestBase
    {
        [Fact]
        public async void GetProductsListRequestHandler_Success()
        {
            var handler = new GetProductsListRequestHandler(Context);

            var result = await handler.Handle(new GetProductsListRequest(), CancellationToken.None);

            result.Count.ShouldBe(4);
        }
    }
}
