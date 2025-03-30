using Application.Features.Mediatr.Products.Queries;
using Application.Features.Mediatr.Products.Results;
using Application.Interfaces;
using MediatR;

namespace Application.Features.Mediatr.Products.Handlers.Read
{
    public class GetProductCountQueryHandler : IRequestHandler<GetProductCountQuery, GetProductCountQueryResult>
    {
        private readonly IProductRepository _productRepository;

        public GetProductCountQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<GetProductCountQueryResult> Handle(GetProductCountQuery request, CancellationToken cancellationToken)
        {
            int count = await _productRepository.GetProductCount();
            return new GetProductCountQueryResult
            {
                ProductCount = count,
            };
        }
    }
}
