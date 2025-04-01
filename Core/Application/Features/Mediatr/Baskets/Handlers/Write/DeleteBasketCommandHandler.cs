using Application.Features.Mediatr.Baskets.Commands;
using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Features.Mediatr.Baskets.Handlers.Write
{
    public class DeleteBasketCommandHandler:IRequestHandler<DeleteBasketCommand>
    {
        private readonly IGenericRepository<Basket> _repository;

        public DeleteBasketCommandHandler(IGenericRepository<Basket> repository)
        {
            _repository = repository;
        }

        public async Task Handle(DeleteBasketCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            await _repository.DeleteAsync(value);
        }
    }
}
