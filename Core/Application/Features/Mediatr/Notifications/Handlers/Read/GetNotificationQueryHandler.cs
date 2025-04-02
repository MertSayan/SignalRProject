using Application.Features.Mediatr.Notifications.Queries;
using Application.Features.Mediatr.Notifications.Results;
using Application.Interfaces;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Features.Mediatr.Notifications.Handlers.Read
{
	public class GetNotificationQueryHandler:IRequestHandler<GetNotificationQuery,List<GetNotificationQueryResult>>
	{
		private readonly IGenericRepository<Notification> _repository;
		private readonly IMapper _mapper;
		public GetNotificationQueryHandler(IGenericRepository<Notification> repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}

		public async Task<List<GetNotificationQueryResult>> Handle(GetNotificationQuery request, CancellationToken cancellationToken)
		{
			var values = await _repository.GetListAllAsync();
			return _mapper.Map<List<GetNotificationQueryResult>>(values);
		}
	}
}
