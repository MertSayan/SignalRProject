using Application.Features.Mediatr.Contacts.Commands;
using Application.Interfaces;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Features.Mediatr.Contacts.Handlers.Write
{
    public class UpdateContactCommandHandler:IRequestHandler<UpdateContactCommand>
    {
        private readonly IGenericRepository<Contact> _repository;
        private readonly IMapper _mapper;

        public UpdateContactCommandHandler(IGenericRepository<Contact> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(UpdateContactCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.ContactId);
            _mapper.Map(request, value);
            await _repository.UpdateAsync(value);

        }
    }
}
