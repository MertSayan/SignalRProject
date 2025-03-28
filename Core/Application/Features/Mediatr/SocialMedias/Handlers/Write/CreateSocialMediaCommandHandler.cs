using Application.Features.Mediatr.SocialMedias.Commands;
using Application.Interfaces;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Features.Mediatr.SocialMedias.Handlers.Write
{
    public class CreateSocialMediaCommandHandler:IRequestHandler<CreateSocialMediaCommand>
    {
        private readonly IGenericRepository<SocialMedia> _genericRepository;
        private readonly IMapper _mapper;

        public CreateSocialMediaCommandHandler(IGenericRepository<SocialMedia> genericRepository, IMapper mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }

        public async Task Handle(CreateSocialMediaCommand request, CancellationToken cancellationToken)
        {

            var value = _mapper.Map<SocialMedia>(request);
            await _genericRepository.CreateAsync(value);
        }
    }
}
