using Application.Features.Mediatr.Categories.Results;
using MediatR;

namespace Application.Features.Mediatr.Categories.Queries
{
    public class GetCategoryQuery:IRequest<List<GetCategoryQueryResult>>
    {
    }
}
