using Application.Features.Mediatr.Notifications.Queries;
using Application.Features.Mediatr.Notifications.Results;
using Application.Interfaces;
using MediatR;

namespace Application.Features.Mediatr.Notifications.Handlers.Read
{
	public class GetNotificationCountByNotReadQueryHandler : IRequestHandler<GetNotificationCountByNotReadQuery, GetNotificationCountByNotReadQueryResult>
	{
		private readonly INotificationRepository _notificationRepository;

		public GetNotificationCountByNotReadQueryHandler(INotificationRepository notificationRepository)
		{
			_notificationRepository = notificationRepository;
		}

		public async Task<GetNotificationCountByNotReadQueryResult> Handle(GetNotificationCountByNotReadQuery request, CancellationToken cancellationToken)
		{
			var value=await _notificationRepository.GetNotificationCountByNotRead();
			return new GetNotificationCountByNotReadQueryResult
			{
				Count=value,
			};
		}
	}
}
