using Application.Features.Mediatr.Products.Results;
using MediatR;

namespace Application.Features.Mediatr.Products.Queries
{
    public class GetProductPriceAvgQuery:IRequest<GetProductPriceAvgQueryResult>
    {
    }
}
