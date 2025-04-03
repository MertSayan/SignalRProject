using Application.Constants;
using Application.Features.Mediatr.Bookings.Commands;
using Application.Features.Mediatr.Bookings.Queries;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BookingsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBookingList()
        {
            var values = await _mediator.Send(new GetBookingQuery());
            return Ok(values);
        }
        [HttpGet("ById")]
        public async Task<IActionResult> GetByIdBooking(int id)
        {
            var value = await _mediator.Send(new GetByIdBookingQuery(id));
            return Ok(value);
        }
		[HttpGet("UpdateBookingStatusApproved")]
		public async Task<IActionResult> UpdateBookingStatusApproved(int id)
		{
			await _mediator.Send(new UpdateBookingStatusApprovedCommand(id));
			return Ok("Rezervasyon Onaylandı");
		}
		[HttpGet("UpdateBookingStatusCancelled")]
		public async Task<IActionResult> UpdateBookingStatusCancelled(int id)
		{
			await _mediator.Send(new UpdateBookingStatusCancelledCommand(id));
			return Ok("Rezervasyon İptal Edildi");
		}
		[HttpPost]
        public async Task<IActionResult> CreateBooking(CreateBookingCommand command)
        {
            await _mediator.Send(command);
            return Ok(Messages<Booking>.EntityAdded);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateBooking(UpdateBookingCommand command)
        {
            await _mediator.Send(command);
            return Ok(Messages<Booking>.EntityUpdated);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteBooking(int id)
        {
            await _mediator.Send(new DeleteBookingCommand(id));
            return Ok(Messages<Booking>.EntityDeleted);
        }
    }
}
