using Application.Features.Mediatr.Messages.Commands;
using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Features.Mediatr.Messages.Handlers.Write
{
	public class DeleteMessageCommandHandler:IRequestHandler<DeleteMessageCommand>
	{
		private readonly IGenericRepository<Message> _repository;

		public DeleteMessageCommandHandler(IGenericRepository<Message> repository)
		{
			_repository = repository;
		}

		public async Task Handle(DeleteMessageCommand request, CancellationToken cancellationToken)
		{
			var value = await _repository.GetByIdAsync(request.Id);
			await _repository.DeleteAsync(value);
		}
	}
}
