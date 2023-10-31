using FluentValidation;

namespace Shop.Application.Products.Commands.CreateProduct
{
    public class CreateProductValidation : AbstractValidator<CreateProductCommand>
    {
        public CreateProductValidation()
        {
            RuleFor(createProductCommand => createProductCommand.Title).NotEmpty().MaximumLength(256);
            RuleFor(createProductCommand => createProductCommand.Description).MaximumLength(1024);
        }
    }
}
