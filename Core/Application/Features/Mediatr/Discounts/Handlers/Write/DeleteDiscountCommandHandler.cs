using Application.Features.Mediatr.Discounts.Commands;
using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Features.Mediatr.Discounts.Handlers.Write
{
    public class DeleteDiscountCommandHandler:IRequestHandler<DeleteDiscountCommand>
    {
        private readonly IGenericRepository<Discount> _repository;

        public DeleteDiscountCommandHandler(IGenericRepository<Discount> repository)
        {
            _repository = repository;
        }

        public async Task Handle(DeleteDiscountCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            await _repository.DeleteAsync(value);
        }
    }
}
