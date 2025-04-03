using Application.Features.Mediatr.Bookings.Commands;
using Application.Interfaces;
using MediatR;

namespace Application.Features.Mediatr.Bookings.Handlers.Write
{
	public class UpdateBookingStatusCancelledCommandHandler : IRequestHandler<UpdateBookingStatusCancelledCommand>
	{
		private readonly IBookingRepository _bookingRepository;

		public UpdateBookingStatusCancelledCommandHandler(IBookingRepository bookingRepository)
		{
			_bookingRepository = bookingRepository;
		}

		public async Task Handle(UpdateBookingStatusCancelledCommand request, CancellationToken cancellationToken)
		{
			await _bookingRepository.BookingStatusCancelled(request.Id);
		}
	}
}
