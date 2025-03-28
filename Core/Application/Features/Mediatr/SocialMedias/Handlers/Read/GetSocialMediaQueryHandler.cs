using Application.Features.Mediatr.SocialMedias.Queries;
using Application.Features.Mediatr.SocialMedias.Results;
using Application.Interfaces;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Features.Mediatr.SocialMedias.Handlers.Read
{
    public class GetSocialMediaQueryHandler:IRequestHandler<GetSocialMediaQuery,List<GetSocialMediaQueryResult>>
    {
        private readonly IGenericRepository<SocialMedia> _repository;
        private readonly IMapper _mapper;
        public GetSocialMediaQueryHandler(IGenericRepository<SocialMedia> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetSocialMediaQueryResult>> Handle(GetSocialMediaQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetListAllAsync();
            return _mapper.Map<List<GetSocialMediaQueryResult>>(values);
        }
    }
}
