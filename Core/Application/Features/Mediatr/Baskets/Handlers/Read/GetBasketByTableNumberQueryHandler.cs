using Application.Features.Mediatr.Baskets.Queries;
using Application.Features.Mediatr.Baskets.Results;
using Application.Interfaces;
using AutoMapper;
using MediatR;

namespace Application.Features.Mediatr.Baskets.Handlers.Read
{
    public class GetBasketByTableNumberQueryHandler : IRequestHandler<GetBasketByTableNumberQuery, List<GetBasketByTableNumberQueryResult>>
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IMapper _mapper;
        public GetBasketByTableNumberQueryHandler(IBasketRepository basketRepository, IMapper mapper)
        {
            _basketRepository = basketRepository;
            _mapper = mapper;
        }

        public async Task<List<GetBasketByTableNumberQueryResult>> Handle(GetBasketByTableNumberQuery request, CancellationToken cancellationToken)
        {
            var values = await _basketRepository.GetBasketByTableNumber(request.Id);
            return _mapper.Map<List<GetBasketByTableNumberQueryResult>>(values);
        }
    }
}
