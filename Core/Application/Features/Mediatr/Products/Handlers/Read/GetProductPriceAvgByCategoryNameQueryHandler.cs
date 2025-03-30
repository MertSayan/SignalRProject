using Application.Features.Mediatr.Products.Queries;
using Application.Features.Mediatr.Products.Results;
using Application.Interfaces;
using MediatR;

namespace Application.Features.Mediatr.Products.Handlers.Read
{
    public class GetProductPriceAvgByCategoryNameQueryHandler : IRequestHandler<GetProductPriceAvgByCategoryNameQuery, GetProductPriceAvgByCategoryNameQueryResult>
    {
        private readonly IProductRepository _productRepository;

        public GetProductPriceAvgByCategoryNameQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<GetProductPriceAvgByCategoryNameQueryResult> Handle(GetProductPriceAvgByCategoryNameQuery request, CancellationToken cancellationToken)
        {
            decimal price = await _productRepository.GetProductPriceAvgByCategoryName(request.CategoryName);
            return new GetProductPriceAvgByCategoryNameQueryResult
            {
                AvgProductPrive=price,
            };
        }
    }
}
