using Application.Features.Mediatr.Notifications.Commands;
using Application.Interfaces;
using MediatR;

namespace Application.Features.Mediatr.Notifications.Handlers.Write
{
	public class UpdateNotificationChangeToNotReadCommandHandler : IRequestHandler<UpdateNotificationChangeToNotReadCommand>
	{
		private readonly INotificationRepository _notificationRepository;

		public UpdateNotificationChangeToNotReadCommandHandler(INotificationRepository notificationRepository)
		{
			_notificationRepository = notificationRepository;
		}

		public async Task Handle(UpdateNotificationChangeToNotReadCommand request, CancellationToken cancellationToken)
		{
			await _notificationRepository.NotificationChangeToNotRead(request.Id);
		}
	}
}
