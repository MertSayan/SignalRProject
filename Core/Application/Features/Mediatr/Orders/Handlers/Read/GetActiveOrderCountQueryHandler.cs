using Application.Features.Mediatr.Orders.Queries;
using Application.Features.Mediatr.Orders.Results;
using Application.Interfaces;
using MediatR;

namespace Application.Features.Mediatr.Orders.Handlers.Read
{
    public class GetActiveOrderCountQueryHandler : IRequestHandler<GetActiveOrderCountQuery, GetActiveOrderCountQueryResult>
    {
        private readonly IOrderRepository _orderRepository;

        public GetActiveOrderCountQueryHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<GetActiveOrderCountQueryResult> Handle(GetActiveOrderCountQuery request, CancellationToken cancellationToken)
        {
            int count = await _orderRepository.GetActiveOrderCount();
            return new GetActiveOrderCountQueryResult
            {
                ActiveOrderCount= count,
            };
        }
    }
}
