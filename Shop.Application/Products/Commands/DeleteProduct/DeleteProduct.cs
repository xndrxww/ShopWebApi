using MediatR;
using Shop.Application.Common.Exceptions;
using Shop.Application.Interfaces;

namespace Shop.Application.Products.Commands.DeleteProduct
{
    public class DeleteProductCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }

    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, Unit>
    {
        private readonly IShopDbContext _dbContext;

        public DeleteProductCommandHandler(IShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
        {
            var product = await _dbContext.Products.FindAsync(new object[] { command.Id }, cancellationToken);

            if (product == null)
            {
                throw new NotFoundException(nameof(product), command.Id);
            }

            _dbContext.Products.Remove(product);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
