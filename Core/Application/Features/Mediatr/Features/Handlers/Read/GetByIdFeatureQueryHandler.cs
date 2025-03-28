using Application.Features.Mediatr.Features.Queries;
using Application.Features.Mediatr.Features.Results;
using Application.Interfaces;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Features.Mediatr.Features.Handlers.Read
{
    public class GetByIdFeatureQueryHandler:IRequestHandler<GetByIdFeatureQuery,GetByIdFeatureQueryResult>
    {
        private readonly IGenericRepository<Feature> _repository;
        private readonly IMapper _mapper;
        public GetByIdFeatureQueryHandler(IGenericRepository<Feature> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetByIdFeatureQueryResult> Handle(GetByIdFeatureQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            return _mapper.Map<GetByIdFeatureQueryResult>(value);
        }
    }
}
