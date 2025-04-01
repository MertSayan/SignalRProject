using Application.Features.Mediatr.Baskets.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.Baskets.Queries
{
    public class GetBasketQuery:IRequest<List<GetBasketQueryResult>>
    {
    }
}
