using MediatR;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Interfaces;
using Shop.Domain.Models;

namespace Shop.Application.Products.Requests
{
    public class GetProductsListRequest : IRequest<List<Product>>
    {
    }

    public class GetProductsListRequestHandler : IRequestHandler<GetProductsListRequest, List<Product>>
    {
        private readonly IShopDbContext _dbContext;

        public GetProductsListRequestHandler(IShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Product>> Handle(GetProductsListRequest request, CancellationToken cancellationToken)
        {
            return await _dbContext.Products.ToListAsync(cancellationToken);
        }
    }
}
