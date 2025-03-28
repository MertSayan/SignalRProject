using Application.Features.Mediatr.Abouts.Commands;
using Application.Interfaces;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Features.Mediatr.Abouts.Handlers.Write
{
    public class CreateAboutCommandHandler : IRequestHandler<CreateAboutCommand>
    {
        private readonly IGenericRepository<About> _genericRepository;
        private readonly IMapper _mapper;

        public CreateAboutCommandHandler(IGenericRepository<About> genericRepository, IMapper mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }

        public async Task Handle(CreateAboutCommand request, CancellationToken cancellationToken)
        {

            var value = _mapper.Map<About>(request);
            await _genericRepository.CreateAsync(value);
        }
    }
}
