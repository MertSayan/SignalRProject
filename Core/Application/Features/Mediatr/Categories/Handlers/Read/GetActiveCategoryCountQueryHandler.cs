using Application.Features.Mediatr.Categories.Queries;
using Application.Features.Mediatr.Categories.Results;
using Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.Categories.Handlers.Read
{
    public class GetActiveCategoryCountQueryHandler : IRequestHandler<GetActiveCategoryCountQuery, GetActiveCategoryCountQueryResult>
    {
        private readonly ICategoryRepository _categoryRepository;

        public GetActiveCategoryCountQueryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<GetActiveCategoryCountQueryResult> Handle(GetActiveCategoryCountQuery request, CancellationToken cancellationToken)
        {
            int count = await _categoryRepository.GetActiveCategoryCount();
            return new GetActiveCategoryCountQueryResult
            {
                PassiveCategoryCount=count,
            };
        }
    }
}
