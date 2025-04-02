using MediatR;

namespace Application.Features.Mediatr.Notifications.Commands
{
	public class UpdateNotificationChangeToNotReadCommand:IRequest
	{
		public int Id { get; set; }

		public UpdateNotificationChangeToNotReadCommand(int id)
		{
			Id = id;
		}
	}
}
