using Application.Features.Mediatr.Messages.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.Messages.Queries
{
	public class GetByIdMessageQuery:IRequest<GetByIdMessageQueryResult>
	{
		public int Id { get; set; }

		public GetByIdMessageQuery(int id)
		{
			Id = id;
		}
	}
}
