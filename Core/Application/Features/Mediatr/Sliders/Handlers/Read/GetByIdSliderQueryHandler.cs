using Application.Features.Mediatr.Sliders.Queries;
using Application.Features.Mediatr.Sliders.Results;
using Application.Interfaces;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Features.Mediatr.Sliders.Handlers.Read
{
    public class GetByIdSliderQueryHandler : IRequestHandler<GetByIdSliderQuery, GetByIdSliderQueryResult>
    {
        private readonly IGenericRepository<Slider> _repository;
        private readonly IMapper _mapper;
        public GetByIdSliderQueryHandler(IGenericRepository<Slider> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetByIdSliderQueryResult> Handle(GetByIdSliderQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            return _mapper.Map<GetByIdSliderQueryResult>(value);
        }
    }
}
