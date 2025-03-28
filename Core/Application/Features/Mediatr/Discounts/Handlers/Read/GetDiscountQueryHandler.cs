using Application.Features.Mediatr.Discounts.Queries;
using Application.Features.Mediatr.Discounts.Results;
using Application.Interfaces;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Features.Mediatr.Discounts.Handlers.Read
{
    public class GetDiscountQueryHandler : IRequestHandler<GetDiscountQuery, List<GetDiscountQueryResult>>
    {
        private readonly IGenericRepository<Discount> _repository;
        private readonly IMapper _mapper;
        public GetDiscountQueryHandler(IGenericRepository<Discount> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetDiscountQueryResult>> Handle(GetDiscountQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetListAllAsync();
            return _mapper.Map<List<GetDiscountQueryResult>>(values);
        }
    }
}
