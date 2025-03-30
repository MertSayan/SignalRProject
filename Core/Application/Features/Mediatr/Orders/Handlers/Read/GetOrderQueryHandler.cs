using Application.Features.Mediatr.Orders.Queries;
using Application.Features.Mediatr.Orders.Results;
using Application.Interfaces;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Features.Mediatr.Orders.Handlers.Read
{
    public class GetOrderQueryHandler:IRequestHandler<GetOrderQuery,List<GetOrderQueryResult>>
    {
        private readonly IGenericRepository<Order> _repository;
        private readonly IMapper _mapper;
        public GetOrderQueryHandler(IGenericRepository<Order> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetOrderQueryResult>> Handle(GetOrderQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetListAllAsync();
            return _mapper.Map<List<GetOrderQueryResult>>(values);
        }
    }
}
