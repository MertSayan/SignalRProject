using Application.Features.Mediatr.Baskets.Queries;
using Application.Features.Mediatr.Baskets.Results;
using Application.Interfaces;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Features.Mediatr.Baskets.Handlers.Read
{
    public class GetByIdBasketQueryHandler:IRequestHandler<GetByIdBasketQuery,GetByIdBasketQueryResult>
    {
        private readonly IGenericRepository<Basket> _repository;
        private readonly IMapper _mapper;
        public GetByIdBasketQueryHandler(IGenericRepository<Basket> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetByIdBasketQueryResult> Handle(GetByIdBasketQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            return _mapper.Map<GetByIdBasketQueryResult>(value);
        }
    }
}
