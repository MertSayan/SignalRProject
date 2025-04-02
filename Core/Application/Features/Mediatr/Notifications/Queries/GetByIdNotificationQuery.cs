using Application.Features.Mediatr.Notifications.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.Notifications.Queries
{
	public class GetByIdNotificationQuery:IRequest<GetByIdNotificationQueryResult>
	{
		public int Id { get; set; }

		public GetByIdNotificationQuery(int id)
		{
			Id = id;
		}
	}
}
