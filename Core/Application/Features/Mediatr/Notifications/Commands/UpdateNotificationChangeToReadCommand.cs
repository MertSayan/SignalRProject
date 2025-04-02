using MediatR;

namespace Application.Features.Mediatr.Notifications.Commands
{
	public class UpdateNotificationChangeToReadCommand:IRequest
	{
		public int Id { get; set; }

		public UpdateNotificationChangeToReadCommand(int id)
		{
			Id = id;
		}
	}
}
