using Application.Interfaces;
using Domain;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
	public class BookingRepository : IBookingRepository
	{
		private readonly SignalRContext _context;

		public BookingRepository(SignalRContext context)
		{
			_context = context;
		}

		public async Task BookingStatusApproved(int id)
		{
			var value=await _context.Bookings.FindAsync(id);
			value.Description = "Rezervasyon Onaylandı";
			await _context.SaveChangesAsync();
		}

		public async Task BookingStatusCancelled(int id)
		{
			var value = await _context.Bookings.FindAsync(id);
			value.Description = "Rezervasyon İptal Edildi";
			await _context.SaveChangesAsync();
		}
	}
}
