using Application.Features.Mediatr.Discounts.Queries;
using Application.Features.Mediatr.Discounts.Results;
using Application.Interfaces;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Features.Mediatr.Discounts.Handlers.Read
{
    public class GetByIdDiscountQueryHandler : IRequestHandler<GetByIdDiscountQuery, GetByIdDiscountQueryResult>
    {
        private readonly IGenericRepository<Discount> _repository;
        private readonly IMapper _mapper;
        public GetByIdDiscountQueryHandler(IGenericRepository<Discount> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetByIdDiscountQueryResult> Handle(GetByIdDiscountQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            return _mapper.Map<GetByIdDiscountQueryResult>(value);
        }
    }
}
