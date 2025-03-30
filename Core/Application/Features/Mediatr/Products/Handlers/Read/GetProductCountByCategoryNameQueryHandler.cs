using Application.Features.Mediatr.Products.Queries;
using Application.Features.Mediatr.Products.Results;
using Application.Interfaces;
using MediatR;

namespace Application.Features.Mediatr.Products.Handlers.Read
{
    public class GetProductCountByCategoryNameQueryHandler : IRequestHandler<GetProductCountByCategoryNameQuery, GetProductCountByCategoryNameQueryResult>
    {
        private readonly IProductRepository _productRepository;

        public GetProductCountByCategoryNameQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<GetProductCountByCategoryNameQueryResult> Handle(GetProductCountByCategoryNameQuery request, CancellationToken cancellationToken)
        {
            int count = await _productRepository.GetProductCountByCategoryName(request.CategoryName);
            return new GetProductCountByCategoryNameQueryResult
            {
                ProductCountByCategoryName= count,
            };
        }
    }
}
