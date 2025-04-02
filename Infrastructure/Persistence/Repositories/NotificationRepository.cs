using Application.Interfaces;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repositories
{
	public class NotificationRepository : INotificationRepository
	{
		private readonly SignalRContext _context;

		public NotificationRepository(SignalRContext context)
		{
			_context = context;
		}

		public async Task<List<Notification>> GetAllNotificationByNotRead()
		{
			return await _context.Notifications.Where(x=>x.Status==false).ToListAsync();
		}

		public async Task<int> GetNotificationCountByNotRead()
		{
			return await _context.Notifications.Where(x => x.Status == false).CountAsync();
		}

		public async Task NotificationChangeToNotRead(int id)
		{
			var value = await _context.Notifications.FindAsync(id);
			value.Status = false;
			await _context.SaveChangesAsync();
		}

		public async Task NotificationChangeToRead(int id)
		{
			var value = await _context.Notifications.FindAsync(id);
			value.Status = true;
			await _context.SaveChangesAsync();
		}
	}
}
