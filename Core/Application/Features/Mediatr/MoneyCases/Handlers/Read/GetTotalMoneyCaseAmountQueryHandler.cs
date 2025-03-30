using Application.Features.Mediatr.MoneyCases.Queries;
using Application.Features.Mediatr.MoneyCases.Results;
using Application.Interfaces;
using MediatR;

namespace Application.Features.Mediatr.MoneyCases.Handlers.Read
{
    public class GetTotalMoneyCaseAmountQueryHandler : IRequestHandler<GetTotalMoneyCaseAmountQuery, GetTotalMoneyCaseAmountQueryResult>
    {
        private readonly IMoneyCaseRepository _moneyCaseRepository;

        public GetTotalMoneyCaseAmountQueryHandler(IMoneyCaseRepository moneyCaseRepository)
        {
            _moneyCaseRepository = moneyCaseRepository;
        }

        public async Task<GetTotalMoneyCaseAmountQueryResult> Handle(GetTotalMoneyCaseAmountQuery request, CancellationToken cancellationToken)
        {
            decimal amount = await _moneyCaseRepository.GetTotalMoneyCaseAmount();
            return new GetTotalMoneyCaseAmountQueryResult
            {
                TotalMoneyCaseAmount= amount
            };
        }
    }
}
