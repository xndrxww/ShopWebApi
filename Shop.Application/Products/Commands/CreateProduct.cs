using MediatR;
using Shop.Application.Interfaces;
using Shop.Domain.Enums;
using Shop.Domain.Models;

namespace Shop.Application.Products.Commands
{
    public class CreateProductCommand : IRequest<Guid>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Size Size { get; set; }
        public ushort Quantity { get; set; }
    }

    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Guid>
    {
        private readonly IShopDbContext _dbContext;

        public CreateProductCommandHandler(IShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Guid> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            var product = new Product
            {
                Id = Guid.NewGuid(),
                Title = command.Title,
                Description = command.Description,
                Size = command.Size,
                Quantity = command.Quantity
            };

            await _dbContext.Products.AddAsync(product, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return product.Id;
        }
    }
}
