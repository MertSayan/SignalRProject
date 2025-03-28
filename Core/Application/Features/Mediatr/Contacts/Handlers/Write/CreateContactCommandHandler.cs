using Application.Features.Mediatr.Contacts.Commands;
using Application.Features.Mediatr.Contacts.Commands;
using Application.Interfaces;
using AutoMapper;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.Contacts.Handlers.Write
{
    public class CreateContactCommandHandler:IRequestHandler<CreateContactCommand>
    {
        private readonly IGenericRepository<Contact> _genericRepository;
        private readonly IMapper _mapper;

        public CreateContactCommandHandler(IGenericRepository<Contact> genericRepository, IMapper mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }

        public async Task Handle(CreateContactCommand request, CancellationToken cancellationToken)
        {

            var value = _mapper.Map<Contact>(request);
            await _genericRepository.CreateAsync(value);
        }
    }
}
