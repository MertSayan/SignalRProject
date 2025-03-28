using Application.Features.Mediatr.Discounts.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.Discounts.Queries
{
    public class GetDiscountQuery:IRequest<List<GetDiscountQueryResult>>
    {
    }
}
