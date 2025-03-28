using Application.Features.Mediatr.Features.Commands;
using Application.Features.Mediatr.Features.Commands;
using Application.Interfaces;
using AutoMapper;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.Features.Handlers.Write
{
    public class CreateFeatureCommandHandler:IRequestHandler<CreateFeatureCommand>
    {
        private readonly IGenericRepository<Feature> _genericRepository;
        private readonly IMapper _mapper;

        public CreateFeatureCommandHandler(IGenericRepository<Feature> genericRepository, IMapper mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }

        public async Task Handle(CreateFeatureCommand request, CancellationToken cancellationToken)
        {

            var value = _mapper.Map<Feature>(request);
            await _genericRepository.CreateAsync(value);
        }
    }
}
