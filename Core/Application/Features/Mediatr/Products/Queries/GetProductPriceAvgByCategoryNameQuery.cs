using Application.Features.Mediatr.Products.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.Products.Queries
{
    public class GetProductPriceAvgByCategoryNameQuery:IRequest<GetProductPriceAvgByCategoryNameQueryResult>
    {
        public string CategoryName { get; set; }

        public GetProductPriceAvgByCategoryNameQuery(string categoryName)
        {
            CategoryName = categoryName;
        }
    }
}
