using FluentValidation;

namespace Shop.Application.Products.Commands.UpdateProduct
{
    public class UpdateProductValidation : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductValidation() 
        {
            RuleFor(updateProductCommand => updateProductCommand.Title).NotEmpty().MaximumLength(256);
            RuleFor(updateProductCommand => updateProductCommand.Description).NotEmpty().MaximumLength(1024);
            RuleFor(updateProductCommand => updateProductCommand.Id).NotEqual(Guid.Empty);
        }
    }
}
