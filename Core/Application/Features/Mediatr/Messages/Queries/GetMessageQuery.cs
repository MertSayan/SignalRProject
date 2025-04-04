using Application.Features.Mediatr.Messages.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.Messages.Queries
{
	public class GetMessageQuery:IRequest<List<GetMessageQueryResult>>
	{
	}
}
