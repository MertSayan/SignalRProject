using Application.Features.Mediatr.Baskets.Commands;
using Application.Features.Mediatr.Bookings.Commands;
using Application.Interfaces;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Features.Mediatr.Baskets.Handlers.Write
{
    public class CreateBasketCommandHandler:IRequestHandler<CreateBasketCommand>
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IMapper _mapper;

        public CreateBasketCommandHandler(IBasketRepository basketRepository , IMapper mapper)
        {
            _basketRepository = basketRepository;
            _mapper = mapper;
        }

        public async Task Handle(CreateBasketCommand request, CancellationToken cancellationToken)
        {
            await _basketRepository.CreateBasket(request);
        }
    }
}
