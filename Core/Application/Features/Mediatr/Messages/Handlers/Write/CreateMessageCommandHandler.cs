using Application.Features.Mediatr.Messages.Commands;
using Application.Interfaces;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Features.Mediatr.Messages.Handlers.Write
{
	public class CreateMessageCommandHandler:IRequestHandler<CreateMessageCommand>
	{
		private readonly IGenericRepository<Message> _genericRepository;
		private readonly IMapper _mapper;

		public CreateMessageCommandHandler(IGenericRepository<Message> genericRepository, IMapper mapper)
		{
			_genericRepository = genericRepository;
			_mapper = mapper;
		}

		public async Task Handle(CreateMessageCommand request, CancellationToken cancellationToken)
		{

			var value = _mapper.Map<Message>(request);
			value.Status = false;
			value.MessageSendDate=DateTime.Now;
			await _genericRepository.CreateAsync(value);
		}
	}
}
