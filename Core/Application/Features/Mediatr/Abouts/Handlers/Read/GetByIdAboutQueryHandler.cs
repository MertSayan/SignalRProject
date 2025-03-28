using Application.Features.Mediatr.Abouts.Queries;
using Application.Features.Mediatr.Abouts.Results;
using Application.Interfaces;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Features.Mediatr.Abouts.Handlers.Read
{
    public class GetByIdAboutQueryHandler : IRequestHandler<GetByIdAboutQuery, GetByIdAboutQueryResult>
    {
        private readonly IGenericRepository<About> _repository;
        private readonly IMapper _mapper;
        public GetByIdAboutQueryHandler(IGenericRepository<About> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetByIdAboutQueryResult> Handle(GetByIdAboutQuery request, CancellationToken cancellationToken)
        {
            var value=await _repository.GetByIdAsync(request.Id);
            return _mapper.Map<GetByIdAboutQueryResult>(value);
        }
    }
}
