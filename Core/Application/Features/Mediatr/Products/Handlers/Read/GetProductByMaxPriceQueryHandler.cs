using Application.Features.Mediatr.Products.Queries;
using Application.Features.Mediatr.Products.Results;
using Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.Products.Handlers.Read
{
    public class GetProductByMaxPriceQueryHandler : IRequestHandler<GetProductByMaxPriceQuery, GetProductByMaxPriceQueryResult>
    {
        private readonly IProductRepository _productRepository;

        public GetProductByMaxPriceQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<GetProductByMaxPriceQueryResult> Handle(GetProductByMaxPriceQuery request, CancellationToken cancellationToken)
        {
            string product = await _productRepository.GetProductByMaxPrice();
            return new GetProductByMaxPriceQueryResult
            {
                ProductName= product,
            };
        }
    }
}
