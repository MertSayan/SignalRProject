using Application.Features.Mediatr.Bookings.Commands;
using Application.Interfaces;
using MediatR;

namespace Application.Features.Mediatr.Bookings.Handlers.Write
{
	public class UpdateBookingStatusApprovedCommandHandler : IRequestHandler<UpdateBookingStatusApprovedCommand>
	{
		private readonly IBookingRepository _repository;

		public UpdateBookingStatusApprovedCommandHandler(IBookingRepository repository)
		{
			_repository = repository;
		}

		public async Task Handle(UpdateBookingStatusApprovedCommand request, CancellationToken cancellationToken)
		{
			await _repository.BookingStatusApproved(request.Id);
		}
	}
}
