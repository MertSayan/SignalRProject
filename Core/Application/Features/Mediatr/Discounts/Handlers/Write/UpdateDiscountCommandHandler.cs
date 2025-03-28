using Application.Features.Mediatr.Discounts.Commands;
using Application.Interfaces;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Features.Mediatr.Discounts.Handlers.Write
{
    public class UpdateDiscountCommandHandler:IRequestHandler<UpdateDiscountCommand>
    {
        private readonly IGenericRepository<Discount> _repository;
        private readonly IMapper _mapper;

        public UpdateDiscountCommandHandler(IGenericRepository<Discount> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(UpdateDiscountCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.DiscountId);
            _mapper.Map(request, value);
            await _repository.UpdateAsync(value);


        }
    }
}
