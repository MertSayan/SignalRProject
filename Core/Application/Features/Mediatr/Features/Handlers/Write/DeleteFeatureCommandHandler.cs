using Application.Features.Mediatr.Features.Commands;
using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Features.Mediatr.Features.Handlers.Write
{
    public class DeleteFeatureCommandHandler:IRequestHandler<DeleteFeatureCommand>
    {
        private readonly IGenericRepository<Feature> _repository;

        public DeleteFeatureCommandHandler(IGenericRepository<Feature> repository)
        {
            _repository = repository;
        }

        public async Task Handle(DeleteFeatureCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            await _repository.DeleteAsync(value);
        }
    }
}
