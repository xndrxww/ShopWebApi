using MediatR;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Common.Exceptions;
using Shop.Application.Interfaces;
using Shop.Domain.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Shop.Application.Products.Requests
{
    public class GetProductDetailsRequest : IRequest<Product>
    {
        public Guid Id { get; set; }
    }

    public class GetProductDetailsRequestHandler : IRequestHandler<GetProductDetailsRequest, Product>
    {
        private readonly IShopDbContext _dbContext;

        public GetProductDetailsRequestHandler(IShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Product> Handle(GetProductDetailsRequest request, CancellationToken cancellationToken)
        {
            var product = await _dbContext.Products.FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);

            if (product == null)
            {
                throw new NotFoundException(nameof(product), request.Id);
            }

            return product;
        }
    }
}
