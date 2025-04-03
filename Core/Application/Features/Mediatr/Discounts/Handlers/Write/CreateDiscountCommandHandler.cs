using Application.Features.Mediatr.Discounts.Commands;
using Application.Interfaces;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Features.Mediatr.Discounts.Handlers.Write
{
    public class CreateDiscountCommandHandler : IRequestHandler<CreateDiscountCommand>
    {
        private readonly IGenericRepository<Discount> _genericRepository;
        private readonly IMapper _mapper;

        public CreateDiscountCommandHandler(IGenericRepository<Discount> genericRepository, IMapper mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }

        public async Task Handle(CreateDiscountCommand request, CancellationToken cancellationToken)
        {

            var value = _mapper.Map<Discount>(request);
            value.Status = false;
            await _genericRepository.CreateAsync(value);
        }
    }
}
