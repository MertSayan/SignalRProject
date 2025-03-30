using Application.Features.Mediatr.Orders.Queries;
using Application.Features.Mediatr.Orders.Results;
using Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.Orders.Handlers.Read
{
    public class GetLastOrderPriceQueryHandler : IRequestHandler<GetLastOrderPriceQuery, GetLastOrderPriceQueryResult>
    {
        private readonly IOrderRepository _orderRepository;

        public GetLastOrderPriceQueryHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<GetLastOrderPriceQueryResult> Handle(GetLastOrderPriceQuery request, CancellationToken cancellationToken)
        {
            decimal price = await _orderRepository.GetLastOrderPrice();
            return new GetLastOrderPriceQueryResult
            {
                LastOrderPrice=price,
            };
        }
    }
}
