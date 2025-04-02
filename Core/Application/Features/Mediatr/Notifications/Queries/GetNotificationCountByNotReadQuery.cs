using Application.Features.Mediatr.Notifications.Results;
using MediatR;

namespace Application.Features.Mediatr.Notifications.Queries
{
	public class GetNotificationCountByNotReadQuery:IRequest<GetNotificationCountByNotReadQueryResult>
	{
	}
}
