using Application.Features.Mediatr.MoneyCases.Results;
using MediatR;

namespace Application.Features.Mediatr.MoneyCases.Queries
{
    public class GetTotalMoneyCaseAmountQuery:IRequest<GetTotalMoneyCaseAmountQueryResult>
    {
    }
}
