using Application.Features.Mediatr.Contacts.Queries;
using Application.Features.Mediatr.Contacts.Results;
using Application.Features.Mediatr.Contacts.Queries;
using Application.Features.Mediatr.Contacts.Results;
using Application.Interfaces;
using AutoMapper;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.Contacts.Handlers.Read
{
    public class GetByIdContactQueryHandler : IRequestHandler<GetByIdContactQuery, GetByIdContactQueryResult>
    {
        private readonly IGenericRepository<Contact> _repository;
        private readonly IMapper _mapper;
        public GetByIdContactQueryHandler(IGenericRepository<Contact> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetByIdContactQueryResult> Handle(GetByIdContactQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            return _mapper.Map<GetByIdContactQueryResult>(value);
        }
    }
}
