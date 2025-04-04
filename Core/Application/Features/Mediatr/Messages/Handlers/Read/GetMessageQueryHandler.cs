using Application.Features.Mediatr.Messages.Queries;
using Application.Features.Mediatr.Messages.Results;
using Application.Interfaces;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Features.Mediatr.Messages.Handlers.Read
{
	public class GetMessageQueryHandler:IRequestHandler<GetMessageQuery,List<GetMessageQueryResult>>
	{
		private readonly IGenericRepository<Message> _repository;
		private readonly IMapper _mapper;
		public GetMessageQueryHandler(IGenericRepository<Message> repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}

		public async Task<List<GetMessageQueryResult>> Handle(GetMessageQuery request, CancellationToken cancellationToken)
		{
			var values = await _repository.GetListAllAsync();
			return _mapper.Map<List<GetMessageQueryResult>>(values);
		}
	}
}
