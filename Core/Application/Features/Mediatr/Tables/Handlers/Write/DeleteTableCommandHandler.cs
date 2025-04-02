using Application.Features.Mediatr.Tables.Commands;
using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Features.Mediatr.Tables.Handlers.Write
{
	public class DeleteTableCommandHandler:IRequestHandler<DeleteTableCommand>
	{
		private readonly IGenericRepository<Table> _repository;

		public DeleteTableCommandHandler(IGenericRepository<Table> repository)
		{
			_repository = repository;
		}

		public async Task Handle(DeleteTableCommand request, CancellationToken cancellationToken)
		{
			var value = await _repository.GetByIdAsync(request.Id);
			await _repository.DeleteAsync(value);
		}
	}
}
