using Application.Features.Mediatr.Notifications.Commands;
using Application.Interfaces;
using MediatR;

namespace Application.Features.Mediatr.Notifications.Handlers.Write
{
	public class UpdateNotificationChangeToReadCommandHandler : IRequestHandler<UpdateNotificationChangeToReadCommand>
	{
		private readonly INotificationRepository _notificationRepository;

		public UpdateNotificationChangeToReadCommandHandler(INotificationRepository notificationRepository)
		{
			_notificationRepository = notificationRepository;
		}

		public async Task Handle(UpdateNotificationChangeToReadCommand request, CancellationToken cancellationToken)
		{
			await _notificationRepository.NotificationChangeToRead(request.Id);
		}
	}
}
