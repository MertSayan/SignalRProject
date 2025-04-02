using Application.Features.Mediatr.Notifications.Commands;
using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Features.Mediatr.Notifications.Handlers.Write
{
	public class DeleteNotificationCommandHandler:IRequestHandler<DeleteNotificationCommand>
	{
		private readonly IGenericRepository<Notification> _repository;

		public DeleteNotificationCommandHandler(IGenericRepository<Notification> repository)
		{
			_repository = repository;
		}

		public async Task Handle(DeleteNotificationCommand request, CancellationToken cancellationToken)
		{
			var value = await _repository.GetByIdAsync(request.Id);
			await _repository.DeleteAsync(value);
		}
	}
}
