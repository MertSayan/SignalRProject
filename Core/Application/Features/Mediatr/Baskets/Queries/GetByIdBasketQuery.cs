using Application.Features.Mediatr.Baskets.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.Baskets.Queries
{
    public class GetByIdBasketQuery:IRequest<GetByIdBasketQueryResult>
    {
        public int Id { get; set; }

        public GetByIdBasketQuery(int id)
        {
            Id = id;
        }
    }
}
