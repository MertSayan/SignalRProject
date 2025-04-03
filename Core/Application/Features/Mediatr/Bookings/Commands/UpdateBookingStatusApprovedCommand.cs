using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.Bookings.Commands
{
	public class UpdateBookingStatusApprovedCommand:IRequest
	{
		public int Id { get; set; }

		public UpdateBookingStatusApprovedCommand(int id)
		{
			Id = id;
		}
	}
}
