using Application.Features.Mediatr.Notifications.Commands;
using Application.Interfaces;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Features.Mediatr.Notifications.Handlers.Write
{
	public class CreateNotificationCommandHandler:IRequestHandler<CreateNotificationCommand>
	{
		private readonly IGenericRepository<Notification> _genericRepository;
		private readonly IMapper _mapper;

		public CreateNotificationCommandHandler(IGenericRepository<Notification> genericRepository, IMapper mapper)
		{
			_genericRepository = genericRepository;
			_mapper = mapper;
		}

		public async Task Handle(CreateNotificationCommand request, CancellationToken cancellationToken)
		{
			var value = _mapper.Map<Notification>(request);
			value.Status = false;
			value.Date=Convert.ToDateTime(DateTime.Now.ToShortDateString());
			await _genericRepository.CreateAsync(value);
		}
	}
}
