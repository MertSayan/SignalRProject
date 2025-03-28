using Application.Features.Mediatr.Abouts.Queries;
using Application.Features.Mediatr.Abouts.Results;
using Application.Interfaces;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Features.Mediatr.Abouts.Handlers.Read
{
    public class GetAboutQueryHandler : IRequestHandler<GetAboutQuery, List<GetAboutQueryResult>>
    {
        private readonly IGenericRepository<About> _repository;
        private readonly IMapper _mapper;
        public GetAboutQueryHandler(IGenericRepository<About> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetAboutQueryResult>> Handle(GetAboutQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetListAllAsync();
            return _mapper.Map<List<GetAboutQueryResult>>(values);
        }
    }
}
