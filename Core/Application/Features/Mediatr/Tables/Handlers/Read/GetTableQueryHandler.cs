using Application.Features.Mediatr.Tables.Queries;
using Application.Features.Mediatr.Tables.Results;
using Application.Features.Mediatr.Tables.Queries;
using Application.Features.Mediatr.Tables.Results;
using Application.Interfaces;
using AutoMapper;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.Tables.Handlers.Read
{
	public class GetTableQueryHandler : IRequestHandler<GetTableQuery, List<GetTableQueryResult>>
	{
		private readonly IGenericRepository<Table> _repository;
		private readonly IMapper _mapper;
		public GetTableQueryHandler(IGenericRepository<Table> repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}

		public async Task<List<GetTableQueryResult>> Handle(GetTableQuery request, CancellationToken cancellationToken)
		{
			var values = await _repository.GetListAllAsync();
			return _mapper.Map<List<GetTableQueryResult>>(values);
		}
	}
}
