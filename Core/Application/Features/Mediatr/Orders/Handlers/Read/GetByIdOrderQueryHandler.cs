using Application.Features.Mediatr.Orders.Queries;
using Application.Features.Mediatr.Orders.Results;
using Application.Interfaces;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Features.Mediatr.Orders.Handlers.Read
{
    public class GetByIdOrderQueryHandler:IRequestHandler<GetByIdOrderQuery,GetByIdOrderQueryResult>
    {
        private readonly IGenericRepository<Order> _repository;
        private readonly IMapper _mapper;
        public GetByIdOrderQueryHandler(IGenericRepository<Order> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetByIdOrderQueryResult> Handle(GetByIdOrderQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            return _mapper.Map<GetByIdOrderQueryResult>(value);
        }
    }
}
