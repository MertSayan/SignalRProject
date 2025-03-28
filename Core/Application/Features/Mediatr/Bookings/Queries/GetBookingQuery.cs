using Application.Features.Mediatr.Bookings.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.Bookings.Queries
{
    public class GetBookingQuery:IRequest<List<GetBookingQueryResult>>
    {
        
    }
}
