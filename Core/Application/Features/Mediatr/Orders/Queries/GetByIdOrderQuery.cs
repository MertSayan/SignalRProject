using Application.Features.Mediatr.Orders.Results;
using MediatR;

namespace Application.Features.Mediatr.Orders.Queries
{
    public class GetByIdOrderQuery:IRequest<GetByIdOrderQueryResult>
    {
        public int Id { get; set; }

        public GetByIdOrderQuery(int id)
        {
            Id = id;
        }
    }
}
