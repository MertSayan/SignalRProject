using Application.Features.Mediatr.Products.Results;
using MediatR;

namespace Application.Features.Mediatr.Products.Queries
{
    public class GetProductCountByCategoryNameQuery:IRequest<GetProductCountByCategoryNameQueryResult>
    {
        public string CategoryName { get; set; }

        public GetProductCountByCategoryNameQuery(string categoryName)
        {
            CategoryName = categoryName;
        }
    }
}
