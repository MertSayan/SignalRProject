using Application.Features.Mediatr.Orders.Commands;
using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Features.Mediatr.Orders.Handlers.Write
{
    public class DeleteOrderCommandHandler:IRequestHandler<DeleteOrderCommand>
    {
        private readonly IGenericRepository<Order> _repository;

        public DeleteOrderCommandHandler(IGenericRepository<Order> repository)
        {
            _repository = repository;
        }

        public async Task Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            await _repository.DeleteAsync(value);
        }
    }
}
