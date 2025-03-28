using Application.Features.Mediatr.Products.Queries;
using Application.Features.Mediatr.Products.Results;
using Application.Interfaces;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Features.Mediatr.Products.Handlers.Read
{
    public class GetProductQueryHandler:IRequestHandler<GetProductQuery,List<GetProductQueryResult>>
    {
        private readonly IGenericRepository<Product> _repository;
        private readonly IMapper _mapper;
        public GetProductQueryHandler(IGenericRepository<Product> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetProductQueryResult>> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetListAllAsync();
            return _mapper.Map<List<GetProductQueryResult>>(values);
        }
    }
}
