using Application.Features.Mediatr.Sliders.Commands;
using Application.Features.Mediatr.Sliders.Commands;
using Application.Interfaces;
using AutoMapper;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.Sliders.Handlers.Write
{
    public class CreateSliderCommandHandler:IRequestHandler<CreateSliderCommand>
    {
        private readonly IGenericRepository<Slider> _genericRepository;
        private readonly IMapper _mapper;

        public CreateSliderCommandHandler(IGenericRepository<Slider> genericRepository, IMapper mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }

        public async Task Handle(CreateSliderCommand request, CancellationToken cancellationToken)
        {

            var value = _mapper.Map<Slider>(request);
            await _genericRepository.CreateAsync(value);
        }
    }
}
