using Application.Features.Mediatr.Baskets.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.Baskets.Queries
{
    public class GetBasketByTableNumberQuery:IRequest<List<GetBasketByTableNumberQueryResult>>
    {
        public int Id { get; set; }

        public GetBasketByTableNumberQuery(int id)
        {
            Id = id;
        }
    }
}
