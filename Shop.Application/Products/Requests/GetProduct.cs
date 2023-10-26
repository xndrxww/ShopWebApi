using MediatR;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Common.Exceptions;
using Shop.Application.Interfaces;
using Shop.Domain.Models;

namespace Shop.Application.Products.Requests
{
    public class GetProductRequest : IRequest<Product>
    {
        public Guid Id { get; set; }
    }

    public class GetProductRequestHandler : IRequestHandler<GetProductRequest, Product>
    {
        private readonly IShopDbContext _dbContext;

        public GetProductRequestHandler(IShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Product> Handle(GetProductRequest request, CancellationToken cancellationToken)
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
