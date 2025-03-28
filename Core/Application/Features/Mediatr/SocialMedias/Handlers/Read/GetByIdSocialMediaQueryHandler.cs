using Application.Features.Mediatr.SocialMedias.Queries;
using Application.Features.Mediatr.SocialMedias.Results;
using Application.Interfaces;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Features.Mediatr.SocialMedias.Handlers.Read
{
    public class GetByIdSocialMediaQueryHandler:IRequestHandler<GetByIdSocialMediaQuery,GetByIdSocialMediaQueryResult>
    {
        private readonly IGenericRepository<SocialMedia> _repository;
        private readonly IMapper _mapper;
        public GetByIdSocialMediaQueryHandler(IGenericRepository<SocialMedia> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetByIdSocialMediaQueryResult> Handle(GetByIdSocialMediaQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            return _mapper.Map<GetByIdSocialMediaQueryResult>(value);
        }
    }
}
