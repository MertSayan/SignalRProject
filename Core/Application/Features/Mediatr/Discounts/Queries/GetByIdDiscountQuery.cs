using Application.Features.Mediatr.Discounts.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.Discounts.Queries
{
    public class GetByIdDiscountQuery:IRequest<GetByIdDiscountQueryResult>
    {
        public int Id { get; set; }

        public GetByIdDiscountQuery(int id)
        {
            Id = id;
        }
    }
}
