using Application.Features.Mediatr.Sliders.Commands;
using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Features.Mediatr.Sliders.Handlers.Write
{
    public class DeleteSliderCommandHandler : IRequestHandler<DeleteSliderCommand>
    {
        private readonly IGenericRepository<Slider> _repository;

        public DeleteSliderCommandHandler(IGenericRepository<Slider> repository)
        {
            _repository = repository;
        }

        public async Task Handle(DeleteSliderCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            await _repository.DeleteAsync(value);
        }
    }
}
