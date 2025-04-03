using Application.Features.Mediatr.Discounts.Commands;
using Application.Interfaces;
using MediatR;

namespace Application.Features.Mediatr.Discounts.Handlers.Write
{
    public class ChangeDiscountStatusToTrueCommandHandler : IRequestHandler<ChangeDiscountStatusToTrueCommand>
    {
        private readonly IDiscountRepository _repository;

        public ChangeDiscountStatusToTrueCommandHandler(IDiscountRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(ChangeDiscountStatusToTrueCommand request, CancellationToken cancellationToken)
        {
            await _repository.ChangeStatusToTrue(request.Id);
        }
    }
}
