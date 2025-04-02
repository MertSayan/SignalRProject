using Application.Features.Mediatr.Notifications.Commands;
using Application.Interfaces;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Features.Mediatr.Notifications.Handlers.Write
{
	public class UpdateNotificationCommandHandler:IRequestHandler<UpdateNotificationCommand>
	{
		private readonly IGenericRepository<Notification> _repository;
		private readonly IMapper _mapper;

		public UpdateNotificationCommandHandler(IGenericRepository<Notification> repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}

		public async Task Handle(UpdateNotificationCommand request, CancellationToken cancellationToken)
		{
			var value = await _repository.GetByIdAsync(request.NotificationId);
			value.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
			_mapper.Map(request, value);
			await _repository.UpdateAsync(value);

		}
	}
}
