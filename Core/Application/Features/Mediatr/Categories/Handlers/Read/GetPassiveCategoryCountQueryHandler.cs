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
    public class GetPassiveCategoryCountQueryHandler:IRequestHandler<GetPassiveCategoryCountQuery,GetPassiveCategoryCountQueryResult>
    {
        private readonly ICategoryRepository _categoryRepository;

        public GetPassiveCategoryCountQueryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<GetPassiveCategoryCountQueryResult> Handle(GetPassiveCategoryCountQuery request, CancellationToken cancellationToken)
        {
            int count = await _categoryRepository.GetPassiveCategoryCount();
            return new GetPassiveCategoryCountQueryResult
            {
                PassiveCategoryCount = count,
            };
        }
    }
}
