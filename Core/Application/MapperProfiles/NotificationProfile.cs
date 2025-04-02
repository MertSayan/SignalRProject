using Application.Features.Mediatr.Notifications.Commands;
using Application.Features.Mediatr.Notifications.Results;
using AutoMapper;
using Domain;

namespace Application.MapperProfiles
{
	public class NotificationProfile:Profile
	{
		public NotificationProfile()
		{
			CreateMap<Notification, CreateNotificationCommand>().ReverseMap();
			CreateMap<Notification, UpdateNotificationCommand>().ReverseMap();
			CreateMap<Notification, GetNotificationQueryResult>().ReverseMap();
			CreateMap<Notification, GetByIdNotificationQueryResult>().ReverseMap();
		}
	}
}
