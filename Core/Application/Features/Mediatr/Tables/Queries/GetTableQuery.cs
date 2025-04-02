using Application.Features.Mediatr.Tables.Results;
using MediatR;

namespace Application.Features.Mediatr.Tables.Queries
{
	public class GetTableQuery:IRequest<List<GetTableQueryResult>>
	{
	}
}
