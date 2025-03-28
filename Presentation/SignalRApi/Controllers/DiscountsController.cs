using Application.Constants;
using Application.Features.Mediatr.Discounts.Commands;
using Application.Features.Mediatr.Discounts.Queries;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DiscountsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDiscountList()
        {
            var values = await _mediator.Send(new GetDiscountQuery());
            return Ok(values);
        }
        [HttpGet("ById")]
        public async Task<IActionResult> GetByIdDiscount(int id)
        {
            var value = await _mediator.Send(new GetByIdDiscountQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateDiscount(CreateDiscountCommand command)
        {
            await _mediator.Send(command);
            return Ok(Messages<Discount>.EntityAdded);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateDiscount(UpdateDiscountCommand command)
        {
            await _mediator.Send(command);
            return Ok(Messages<Discount>.EntityUpdated);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteDiscount(int id)
        {
            await _mediator.Send(new DeleteDiscountCommand(id));
            return Ok(Messages<Discount>.EntityDeleted);
        }
    }
}
