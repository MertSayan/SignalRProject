using Application.Features.Mediatr.Sliders.Queries;
using Application.Features.Mediatr.Sliders.Results;
using Application.Interfaces;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Features.Mediatr.Sliders.Handlers.Read
{
    public class GetSliderQueryHandler : IRequestHandler<GetSliderQuery, List<GetSliderQueryResult>>
    {
        private readonly IGenericRepository<Slider> _repository;
        private readonly IMapper _mapper;
        public GetSliderQueryHandler(IGenericRepository<Slider> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetSliderQueryResult>> Handle(GetSliderQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetListAllAsync();
            return _mapper.Map<List<GetSliderQueryResult>>(values);
        }
    }
}
