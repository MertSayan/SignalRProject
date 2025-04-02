using Application.Features.Mediatr.Tables.Results;
using MediatR;

namespace Application.Features.Mediatr.Tables.Queries
{
	public class GetByIdTableQuery:IRequest<GetByIdTableQueryResult>
	{
		public int Id { get; set; }

		public GetByIdTableQuery(int id)
		{
			Id = id;
		}
	}
}
