using Application.Features.Mediatr.Notifications.Queries;
using Application.Features.Mediatr.Notifications.Results;
using Application.Interfaces;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Features.Mediatr.Notifications.Handlers.Read
{
	public class GetByIdNotificationQueryHandler:IRequestHandler<GetByIdNotificationQuery,GetByIdNotificationQueryResult>
	{
		private readonly IGenericRepository<Notification> _repository;
		private readonly IMapper _mapper;
		public GetByIdNotificationQueryHandler(IGenericRepository<Notification> repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}

		public async Task<GetByIdNotificationQueryResult> Handle(GetByIdNotificationQuery request, CancellationToken cancellationToken)
		{
			var value = await _repository.GetByIdAsync(request.Id);
			return _mapper.Map<GetByIdNotificationQueryResult>(value);
		}
	}
}
