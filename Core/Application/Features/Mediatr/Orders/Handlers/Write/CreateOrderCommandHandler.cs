using Application.Features.Mediatr.Orders.Commands;
using Application.Interfaces;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Features.Mediatr.Orders.Handlers.Write
{
    public class CreateOrderCommandHandler:IRequestHandler<CreateOrderCommand>
    {
        private readonly IGenericRepository<Order> _genericRepository;
        private readonly IMapper _mapper;

        public CreateOrderCommandHandler(IGenericRepository<Order> genericRepository, IMapper mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }

        public async Task Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {

            var value = _mapper.Map<Order>(request);
            await _genericRepository.CreateAsync(value);
        }
    }
}
