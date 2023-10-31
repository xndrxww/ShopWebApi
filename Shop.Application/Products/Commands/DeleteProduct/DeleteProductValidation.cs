using FluentValidation;

namespace Shop.Application.Products.Commands.DeleteProduct
{
    public class DeleteProductValidation : AbstractValidator<DeleteProductCommand>
    {
        public DeleteProductValidation() 
        {
            RuleFor(deleteProductCommand => deleteProductCommand.Id).NotEqual(Guid.Empty);
        }
    }
}
