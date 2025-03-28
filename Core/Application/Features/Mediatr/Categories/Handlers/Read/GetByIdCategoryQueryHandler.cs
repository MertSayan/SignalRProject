using Application.Features.Mediatr.Categories.Queries;
using Application.Features.Mediatr.Categories.Results;
using Application.Interfaces;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Features.Mediatr.Categories.Handlers.Read
{
    public class GetByIdCategoryQueryHandler : IRequestHandler<GetByIdCategoryQuery, GetByIdCategoryQueryResult>
    {
        private readonly IGenericRepository<Category> _repository;
        private readonly IMapper _mapper;
        public GetByIdCategoryQueryHandler(IGenericRepository<Category> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetByIdCategoryQueryResult> Handle(GetByIdCategoryQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            return _mapper.Map<GetByIdCategoryQueryResult>(value);
        }
    }
}
