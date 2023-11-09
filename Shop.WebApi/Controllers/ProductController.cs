using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Products.Commands.CreateProduct;
using Shop.Application.Products.Commands.DeleteProduct;
using Shop.Application.Products.Commands.UpdateProduct;
using Shop.Application.Products.Requests;
using Shop.Application.Products.Requests.GetProduct;
using Shop.Domain.Enums;
using Shop.Domain.Models;

namespace Shop.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class ProductController : BaseController
    {
        /// <summary>
        /// Получение списка товаров
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<List<Product>>> GetAll()
        {
            var request = new GetProductsListRequest();
            var productList = await Mediator.Send(request);

            return Ok(productList);
        }

        /// <summary>
        /// Получение товара по id
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<Product>> Get(Guid id)
        {
            var request = new GetProductRequest
            {
                Id = id
            };
            var product = await Mediator.Send(request);

            return Ok(product);
        }

        /// <summary>
        /// Создание нового товара
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
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

        /// <summary>
        /// Редактирование товара по id
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [Authorize]
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

        /// <summary>
        /// Удаление товара по id
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [Authorize]
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
