using Application.Constants;
using Application.Features.Mediatr.Products.Commands;
using Application.Features.Mediatr.Products.Queries;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProductList()
        {
            var values = await _mediator.Send(new GetProductQuery());
            return Ok(values);
        }
        [HttpGet("ById")]
        public async Task<IActionResult> GetByIdProduct(int id)
        {
            var value = await _mediator.Send(new GetByIdProductQuery(id));
            return Ok(value);
        }
        [HttpGet("GetProductWithCategoryName")]
        public async Task<IActionResult> GetProductWithCategoryName()
        {
            var value = await _mediator.Send(new GetProductWithCategoryNameQuery());
            return Ok(value);
        }
        [HttpGet("GetProductCount")]
        public async Task<IActionResult> GetProductCount()
        {
            var value = await _mediator.Send(new GetProductCountQuery());
            return Ok(value);
        }
        [HttpGet("GetProductCountByCategoryName")]
        public async Task<IActionResult> GetProductCountByCategoryName(string categoryName)
        {
            var value = await _mediator.Send(new GetProductCountByCategoryNameQuery(categoryName));
            return Ok(value);
        }
        [HttpGet("GetProductPriceAvg")]
        public async Task<IActionResult> GetProductPriceAvg()
        {
            var value = await _mediator.Send(new GetProductPriceAvgQuery());
            return Ok(value);
        }
        [HttpGet("GetProducByMinPrice")]
        public async Task<IActionResult> GetProducByMinPrice()
        {
            var value = await _mediator.Send(new GetProductByMinPriceQuery());
            return Ok(value);
        }
        [HttpGet("GetProducByMaxPrice")]
        public async Task<IActionResult> GetProducByMaxPrice()
        {
            var value = await _mediator.Send(new GetProductByMaxPriceQuery());
            return Ok(value);
        }
        [HttpGet("GetProductPriceAvgByCategoryName")]
        public async Task<IActionResult> GetProductPriceAvgByCategoryName(string categoryName)
        {
            var value = await _mediator.Send(new GetProductPriceAvgByCategoryNameQuery(categoryName));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductCommand command)
        {
            await _mediator.Send(command);
            return Ok(Messages<Product>.EntityAdded);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateProduct(UpdateProductCommand command)
        {
            await _mediator.Send(command);
            return Ok(Messages<Product>.EntityUpdated);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _mediator.Send(new DeleteProductCommand(id));
            return Ok(Messages<Product>.EntityDeleted);
        }
    }
}
