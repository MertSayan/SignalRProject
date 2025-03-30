using Application.Features.Mediatr.Products.Queries;
using Application.Features.Mediatr.Products.Results;
using Application.Interfaces;
using MediatR;

namespace Application.Features.Mediatr.Products.Handlers.Read
{
    public class GetProductPriceAvgQueryHandler : IRequestHandler<GetProductPriceAvgQuery, GetProductPriceAvgQueryResult>
    {
        private readonly IProductRepository _productRepository;

        public GetProductPriceAvgQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<GetProductPriceAvgQueryResult> Handle(GetProductPriceAvgQuery request, CancellationToken cancellationToken)
        {
            decimal avg = await _productRepository.GetProductPriceAvg();
            return new GetProductPriceAvgQueryResult
            {
                AvgProductPrice=avg,
            };
        }
    }
}
