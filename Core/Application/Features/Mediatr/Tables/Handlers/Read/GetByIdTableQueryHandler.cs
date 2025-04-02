using Application.Features.Mediatr.Tables.Queries;
using Application.Features.Mediatr.Tables.Results;
using Application.Interfaces;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Features.Mediatr.Tables.Handlers.Read
{
	public class GetByIdTableQueryHandler:IRequestHandler<GetByIdTableQuery,GetByIdTableQueryResult>
	{
		private readonly IGenericRepository<Table> _repository;
		private readonly IMapper _mapper;
		public GetByIdTableQueryHandler(IGenericRepository<Table> repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}

		public async Task<GetByIdTableQueryResult> Handle(GetByIdTableQuery request, CancellationToken cancellationToken)
		{
			var value = await _repository.GetByIdAsync(request.Id);
			return _mapper.Map<GetByIdTableQueryResult>(value);
		}
	}
}
