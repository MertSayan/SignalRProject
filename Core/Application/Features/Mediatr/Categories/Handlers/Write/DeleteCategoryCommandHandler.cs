using Application.Features.Mediatr.Categories.Commands;
using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Features.Mediatr.Categories.Handlers.Write
{
    public class DeleteCategoryCommandHandler:IRequestHandler<DeleteCategoryCommand>
    {
        private readonly IGenericRepository<Category> _repository;

        public DeleteCategoryCommandHandler(IGenericRepository<Category> repository)
        {
            _repository = repository;
        }

        public async Task Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            await _repository.DeleteAsync(value);
        }
    }
}
