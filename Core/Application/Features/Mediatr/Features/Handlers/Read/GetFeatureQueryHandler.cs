using Application.Features.Mediatr.Features.Queries;
using Application.Features.Mediatr.Features.Results;
using Application.Interfaces;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Features.Mediatr.Features.Handlers.Read
{
    public class GetFeatureQueryHandler:IRequestHandler<GetFeatureQuery,List<GetFeatureQueryResult>>
    {
        private readonly IGenericRepository<Feature> _repository;
        private readonly IMapper _mapper;
        public GetFeatureQueryHandler(IGenericRepository<Feature> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetFeatureQueryResult>> Handle(GetFeatureQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetListAllAsync();
            return _mapper.Map<List<GetFeatureQueryResult>>(values);
        }
    }
}
