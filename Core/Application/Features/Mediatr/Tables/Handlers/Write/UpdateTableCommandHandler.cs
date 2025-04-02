using Application.Features.Mediatr.Tables.Commands;
using Application.Interfaces;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Features.Mediatr.Tables.Handlers.Write
{
	public class UpdateTableCommandHandler:IRequestHandler<UpdateTableCommand>
	{
		private readonly IGenericRepository<Table> _repository;
		private readonly IMapper _mapper;

		public UpdateTableCommandHandler(IGenericRepository<Table> repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}

		public async Task Handle(UpdateTableCommand request, CancellationToken cancellationToken)
		{
			var value = await _repository.GetByIdAsync(request.TableId);
			_mapper.Map(request, value);
			await _repository.UpdateAsync(value);
		}
	}
}
