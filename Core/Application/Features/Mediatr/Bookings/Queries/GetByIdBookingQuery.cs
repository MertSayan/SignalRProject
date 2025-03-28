using Application.Features.Mediatr.Bookings.Results;
using MediatR;

namespace Application.Features.Mediatr.Bookings.Queries
{
    public class GetByIdBookingQuery:IRequest<GetByIdBookingQueryResult>
    {
        public int Id { get; set; }

        public GetByIdBookingQuery(int id)
        {
            Id = id;
        }
    }
}
