using Application.Features.Mediatr.Orders.Commands;
using Application.Features.Mediatr.Orders.Commands;
using Application.Interfaces;
using AutoMapper;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.Orders.Handlers.Write
{
    public class UpdateOrderCommandHandler:IRequestHandler<UpdateOrderCommand>
    {
        private readonly IGenericRepository<Order> _repository;
        private readonly IMapper _mapper;

        public UpdateOrderCommandHandler(IGenericRepository<Order> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.OrderId);
            _mapper.Map(request, value);
            await _repository.UpdateAsync(value);

        }
    }
}
