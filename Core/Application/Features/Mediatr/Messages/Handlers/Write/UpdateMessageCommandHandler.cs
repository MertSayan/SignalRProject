using Application.Features.Mediatr.Messages.Commands;
using Application.Interfaces;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Features.Mediatr.Messages.Handlers.Write
{
	public class UpdateMessageCommandHandler:IRequestHandler<UpdateMessageCommand>
	{
		private readonly IGenericRepository<Message> _repository;
		private readonly IMapper _mapper;

		public UpdateMessageCommandHandler(IGenericRepository<Message> repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}

		public async Task Handle(UpdateMessageCommand request, CancellationToken cancellationToken)
		{
			var value = await _repository.GetByIdAsync(request.MessageId);
			_mapper.Map(request, value);
			await _repository.UpdateAsync(value);

		}
	}
}
