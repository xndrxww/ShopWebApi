using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Products.Commands;
using Shop.Application.Products.Requests;
using Shop.Domain.Enums;
using Shop.Domain.Models;

namespace Shop.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetAll()
        {
            var request = new GetProductsListRequest();
            var productList = await Mediator.Send(request);

            return Ok(productList);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> Get(Guid id)
        {
            var request = new GetProductRequest
            {
                Id = id
            };
            var product = await Mediator.Send(request);

            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult> Create(string title, string description, Size size, ushort quantity)
        {
            var command = new CreateProductCommand()
            {
                Title = title,
                Description = description,
                Size = size,
                Quantity = quantity
            };
            var productId = await Mediator.Send(command);

            return Ok(productId);
        }

        [HttpPut]
        public async Task<IActionResult> Update(Guid id, string title, string description, Size size, ushort quantity)
        {
            var command = new UpdateProductCommand()
            {
                Id = id,
                Title = title,
                Description = description,
                Size = size,
                Quantity = quantity
            };
            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteProductCommand
            {
                Id = id
            };
            await Mediator.Send(command);

            return NoContent();
        }

    }
}
