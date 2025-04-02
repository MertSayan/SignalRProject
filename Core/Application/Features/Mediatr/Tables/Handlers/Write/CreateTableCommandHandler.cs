using Application.Features.Mediatr.Tables.Commands;
using Application.Interfaces;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Features.Mediatr.Tables.Handlers.Write
{
	public class CreateTableCommandHandler:IRequestHandler<CreateTableCommand>
	{
		private readonly IGenericRepository<Table> _genericRepository;
		private readonly IMapper _mapper;

		public CreateTableCommandHandler(IGenericRepository<Table> genericRepository, IMapper mapper)
		{
			_genericRepository = genericRepository;
			_mapper = mapper;
		}

		public async Task Handle(CreateTableCommand request, CancellationToken cancellationToken)
		{

			var value = _mapper.Map<Table>(request);
			value.Status = false;
			await _genericRepository.CreateAsync(value);
		}
	}
}
