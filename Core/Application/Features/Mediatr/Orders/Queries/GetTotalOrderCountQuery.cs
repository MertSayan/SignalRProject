using Application.Features.Mediatr.Orders.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.Orders.Queries
{
    public class GetTotalOrderCountQuery:IRequest<GetTotalOrderCountQueryResult>
    {
    }
}
