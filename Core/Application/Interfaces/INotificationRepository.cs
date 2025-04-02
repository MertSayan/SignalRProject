using Domain;

namespace Application.Interfaces
{
	public interface INotificationRepository
	{
		Task<int> GetNotificationCountByNotRead();

		Task<List<Notification>> GetAllNotificationByNotRead();

		Task NotificationChangeToRead(int id);
		Task NotificationChangeToNotRead(int id);
	}
}
