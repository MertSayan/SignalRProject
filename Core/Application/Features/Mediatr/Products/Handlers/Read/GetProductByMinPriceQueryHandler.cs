using Application.Features.Mediatr.Products.Queries;
using Application.Features.Mediatr.Products.Results;
using Application.Interfaces;
using MediatR;

namespace Application.Features.Mediatr.Products.Handlers.Read
{
    public class GetProductByMinPriceQueryHandler : IRequestHandler<GetProductByMinPriceQuery, GetProductByMinPriceQueryResult>
    {
        private readonly IProductRepository _productRepository;

        public GetProductByMinPriceQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<GetProductByMinPriceQueryResult> Handle(GetProductByMinPriceQuery request, CancellationToken cancellationToken)
        {
            string product = await _productRepository.GetProductByMinPrice();
            return new GetProductByMinPriceQueryResult
            {
                ProductName= product,
            };
        }
    }
}
