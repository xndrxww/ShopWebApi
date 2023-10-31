using FluentValidation;

namespace Shop.Application.Products.Requests.GetProduct
{
    public class GetProductValidation : AbstractValidator<GetProductRequest>
    {
        public GetProductValidation()
        {
            RuleFor(getProductRequest => getProductRequest.Id).NotEqual(Guid.Empty);
        }
    }
}
