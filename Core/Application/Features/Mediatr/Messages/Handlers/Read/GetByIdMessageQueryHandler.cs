using Application.Features.Mediatr.Messages.Queries;
using Application.Features.Mediatr.Messages.Results;
using Application.Interfaces;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Features.Mediatr.Messages.Handlers.Read
{
	public class GetByIdMessageQueryHandler:IRequestHandler<GetByIdMessageQuery,GetByIdMessageQueryResult>
	{
		private readonly IGenericRepository<Message> _repository;
		private readonly IMapper _mapper;
		public GetByIdMessageQueryHandler(IGenericRepository<Message> repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}

		public async Task<GetByIdMessageQueryResult> Handle(GetByIdMessageQuery request, CancellationToken cancellationToken)
		{
			var value = await _repository.GetByIdAsync(request.Id);
			return _mapper.Map<GetByIdMessageQueryResult>(value);
		}
	}
}
