using Application.Features.Mediatr.Categories.Queries;
using Application.Features.Mediatr.Categories.Results;
using Application.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.Categories.Handlers.Read
{
    public class GetCategoryCountQueryHandler : IRequestHandler<GetCategoryCountQuery, GetCategoryCountQueryResult>
    {
        private readonly ICategoryRepository _categoryRepository;

        public GetCategoryCountQueryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;

        }

        public async Task<GetCategoryCountQueryResult> Handle(GetCategoryCountQuery request, CancellationToken cancellationToken)
        {
            int value = await _categoryRepository.GetCategoryCount();
            return new GetCategoryCountQueryResult
            {
                CategoryCount= value, 
            };
        }
    }
}
