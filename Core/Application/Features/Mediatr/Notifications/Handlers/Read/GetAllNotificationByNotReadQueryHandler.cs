using Application.Features.Mediatr.Notifications.Queries;
using Application.Features.Mediatr.Notifications.Results;
using Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.Notifications.Handlers.Read
{
	public class GetAllNotificationByNotReadQueryHandler : IRequestHandler<GetAllNotificationByNotReadQuery, List<GetAllNotificationByNotReadQueryResult>>
	{
		private readonly INotificationRepository _notificationRepository;

		public GetAllNotificationByNotReadQueryHandler(INotificationRepository notificationRepository)
		{
			_notificationRepository = notificationRepository;
		}

		public async Task<List<GetAllNotificationByNotReadQueryResult>> Handle(GetAllNotificationByNotReadQuery request, CancellationToken cancellationToken)
		{
			var values = await _notificationRepository.GetAllNotificationByNotRead();
			return values.Select(x=> new GetAllNotificationByNotReadQueryResult
			{
				Date = x.Date,
				Description = x.Description,
				NotificationId = x.NotificationId,
				Status = x.Status,
				Type=x.Type,
			}).ToList();
		}
	}
}
