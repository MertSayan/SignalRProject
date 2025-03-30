using Application.Constants;
using Application.Features.Mediatr.Orders.Commands;
using Application.Features.Mediatr.Orders.Queries;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrderList()
        {
            var values = await _mediator.Send(new GetOrderQuery());
            return Ok(values);
        }
        [HttpGet("ById")]
        public async Task<IActionResult> GetByIdOrder(int id)
        {
            var value = await _mediator.Send(new GetByIdOrderQuery(id));
            return Ok(value);
        }
        [HttpGet("GetTotalOrderCount")]
        public async Task<IActionResult> GetTotalOrderCount()
        {
            var value = await _mediator.Send(new GetTotalOrderCountQuery());
            return Ok(value);
        }
        [HttpGet("GetActiveOrderCount")]
        public async Task<IActionResult> GetActiveOrderCount()
        {
            var value = await _mediator.Send(new GetActiveOrderCountQuery());
            return Ok(value);
        }
        [HttpGet("GetLastOrderPrice")]
        public async Task<IActionResult> GetLastOrderPrice()
        {
            var value = await _mediator.Send(new GetLastOrderPriceQuery());
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrder(CreateOrderCommand command)
        {
            await _mediator.Send(command);
            return Ok(Messages<Order>.EntityAdded);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateOrder(UpdateOrderCommand command)
        {
            await _mediator.Send(command);
            return Ok(Messages<Order>.EntityUpdated);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            await _mediator.Send(new DeleteOrderCommand(id));
            return Ok(Messages<Order>.EntityDeleted);
        }
    }
}
