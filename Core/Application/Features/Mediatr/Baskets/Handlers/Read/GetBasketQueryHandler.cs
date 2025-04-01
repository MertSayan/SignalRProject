using Application.Features.Mediatr.Baskets.Queries;
using Application.Features.Mediatr.Baskets.Results;
using Application.Interfaces;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Features.Mediatr.Baskets.Handlers.Read
{
    public class GetBasketQueryHandler:IRequestHandler<GetBasketQuery,List<GetBasketQueryResult>>
    {
        private readonly IGenericRepository<Basket> _repository;
        private readonly IMapper _mapper;
        public GetBasketQueryHandler(IGenericRepository<Basket> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetBasketQueryResult>> Handle(GetBasketQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetListAllAsync();
            return _mapper.Map<List<GetBasketQueryResult>>(values);
        }
    }
}
