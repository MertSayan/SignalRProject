using Application.Features.Mediatr.Discounts.Queries;
using Application.Features.Mediatr.Discounts.Results;
using Application.Interfaces;
using AutoMapper;
using MediatR;

namespace Application.Features.Mediatr.Discounts.Handlers.Read
{
	public class GetDiscountListByStatusTrueQueryHandler : IRequestHandler<GetDiscountListByStatusTrueQuery, List<GetDiscountListByStatusTrueQueryResult>>
	{
		private readonly IDiscountRepository _discountRepository;
		private readonly IMapper _mapper;

		public GetDiscountListByStatusTrueQueryHandler(IDiscountRepository discountRepository, IMapper mapper)
		{
			_discountRepository = discountRepository;
			_mapper = mapper;
		}

		public async Task<List<GetDiscountListByStatusTrueQueryResult>> Handle(GetDiscountListByStatusTrueQuery request, CancellationToken cancellationToken)
		{
			var values = await _discountRepository.GetListByStatusTrue();
			return _mapper.Map<List<GetDiscountListByStatusTrueQueryResult>>(values);
		}
	}
}
