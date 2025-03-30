using Application.Features.Mediatr.Orders.Queries;
using Application.Features.Mediatr.Orders.Results;
using Application.Interfaces;
using MediatR;

namespace Application.Features.Mediatr.Orders.Handlers.Read
{
    public class GetTotalOrderCountQueryHandler : IRequestHandler<GetTotalOrderCountQuery, GetTotalOrderCountQueryResult>
    {
        private readonly IOrderRepository _orderRepository;

        public GetTotalOrderCountQueryHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<GetTotalOrderCountQueryResult> Handle(GetTotalOrderCountQuery request, CancellationToken cancellationToken)
        {
            int count = await _orderRepository.GetTotalOrderCount();
            return new GetTotalOrderCountQueryResult
            {
                TotalOrderCount= count,
            };
        }
    }
}
