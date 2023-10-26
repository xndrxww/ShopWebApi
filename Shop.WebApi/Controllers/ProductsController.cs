using Microsoft.AspNetCore.Mvc;
using Shop.Application.Products.Commands;
using Shop.Application.Products.Requests;
using Shop.Domain.Models;

namespace Shop.WebApi.Controllers
{
    public class ProductsController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetAll()
        {
            var request = new GetProductsListRequest();
            var productList = await Mediator.Send(request);
            return Ok(productList);
        }

        public async Task<ActionResult<Product>> Get(Guid id)
        {
            var request = new GetProductRequest
            {
                Id = id
            };
            var product = await Mediator.Send(request);
            return Ok(product);
        }

        public async Task Create(string title, string description, ushort quantity, )
        {
            var command = new CreateProductCommand()
            {
                Title = title,
                Description = description,
                Quantity = quantity,
            };
        }
    }
}
