using Application.Features.Mediatr.Contacts.Queries;
using Application.Features.Mediatr.Contacts.Results;
using Application.Interfaces;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Features.Mediatr.Contacts.Handlers.Read
{
    public class GetContactQueryHandler : IRequestHandler<GetContactQuery, List<GetContactQueryResult>>
    {
        private readonly IGenericRepository<Contact> _repository;
        private readonly IMapper _mapper;
        public GetContactQueryHandler(IGenericRepository<Contact> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetContactQueryResult>> Handle(GetContactQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetListAllAsync();
            return _mapper.Map<List<GetContactQueryResult>>(values);
        }
    }
}
