using Application.Features.Mediatr.SocialMedias.Commands;
using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Features.Mediatr.SocialMedias.Handlers.Write
{
    public class DeleteSocialMediaCommandHandler : IRequestHandler<DeleteSocialMediaCommand>
    {
        private readonly IGenericRepository<SocialMedia> _repository;

        public DeleteSocialMediaCommandHandler(IGenericRepository<SocialMedia> repository)
        {
            _repository = repository;
        }

        public async Task Handle(DeleteSocialMediaCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            await _repository.DeleteAsync(value);
        }
    }
}
