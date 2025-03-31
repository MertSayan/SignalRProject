using Application.Features.Mediatr.Sliders.Commands;
using Application.Interfaces;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Features.Mediatr.Sliders.Handlers.Write
{
    public class UpdateSliderCommandHandler:IRequestHandler<UpdateSliderCommand>
    {
        private readonly IGenericRepository<Slider> _repository;
        private readonly IMapper _mapper;

        public UpdateSliderCommandHandler(IGenericRepository<Slider> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(UpdateSliderCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.SliderId);
            _mapper.Map(request, value);
            await _repository.UpdateAsync(value);

        }
    }
}
