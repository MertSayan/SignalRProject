using Application.Constants;
using Application.Features.Mediatr.Baskets.Commands;
using Application.Features.Mediatr.Baskets.Queries;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BasketsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBasketList()
        {
            var values = await _mediator.Send(new GetBasketQuery());
            return Ok(values);
        }
        [HttpGet("ById")]
        public async Task<IActionResult> GetByIdBasket(int id)
        {
            var value = await _mediator.Send(new GetByIdBasketQuery(id));
            return Ok(value);
        }
        [HttpGet("GetBasketByTableNumber")]
        public async Task<IActionResult> GetBasketByTableNumber(int id)
        {
            var value = await _mediator.Send(new GetBasketByTableNumberQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateBasket(CreateBasketCommand command)
        {
            await _mediator.Send(command);
            return Ok(Messages<Basket>.EntityAdded);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateBasket(UpdateBasketCommand command)
        {
            await _mediator.Send(command);
            return Ok(Messages<Basket>.EntityUpdated);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteBasket(int id)
        {
            await _mediator.Send(new DeleteBasketCommand(id));
            return Ok(Messages<Basket>.EntityDeleted);
        }

    }
}
