using Application.Features.Mediatr.Products.Queries;
using Application.Features.Mediatr.Products.Results;
using Application.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.Products.Handlers.Read
{
    public class GetProductWithCategoryNameQueryHandler : IRequestHandler<GetProductWithCategoryNameQuery, List<GetProductWithCategoryNameQueryResult>>
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;

        public GetProductWithCategoryNameQueryHandler(IMapper mapper, IProductRepository productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<List<GetProductWithCategoryNameQueryResult>> Handle(GetProductWithCategoryNameQuery request, CancellationToken cancellationToken)
        {
            var values = await _productRepository.GetAllProductWithCategories();
            return _mapper.Map<List<GetProductWithCategoryNameQueryResult>>(values);
        }
    }
}
