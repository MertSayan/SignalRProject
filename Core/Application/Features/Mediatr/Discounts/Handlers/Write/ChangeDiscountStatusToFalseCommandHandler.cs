using Application.Features.Mediatr.Discounts.Commands;
using Application.Interfaces;
using MediatR;

namespace Application.Features.Mediatr.Discounts.Handlers.Write
{
    public class ChangeDiscountStatusToFalseCommandHandler : IRequestHandler<ChangeDiscountStatusToFalseCommand>
    {
        private readonly IDiscountRepository _repository;

        public ChangeDiscountStatusToFalseCommandHandler(IDiscountRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(ChangeDiscountStatusToFalseCommand request, CancellationToken cancellationToken)
        {
            await _repository.ChangeStatusToFalse(request.Id);
        }
    }
}
