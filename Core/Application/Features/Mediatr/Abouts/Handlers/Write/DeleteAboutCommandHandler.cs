using Application.Features.Mediatr.Abouts.Commands;
using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Features.Mediatr.Abouts.Handlers.Write
{
    public class DeleteAboutCommandHandler : IRequestHandler<DeleteAboutCommand>
    {
        private readonly IGenericRepository<About> _repository;

        public DeleteAboutCommandHandler(IGenericRepository<About> repository)
        {
            _repository = repository;
        }

        public async Task Handle(DeleteAboutCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            await _repository.DeleteAsync(value);
        }
    }
}
