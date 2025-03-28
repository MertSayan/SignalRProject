using Application.Features.Mediatr.Categories.Results;
using MediatR;

namespace Application.Features.Mediatr.Categories.Queries
{
    public class GetByIdCategoryQuery:IRequest<GetByIdCategoryQueryResult>
    {
        public int Id { get; set; }

        public GetByIdCategoryQuery(int id)
        {
            Id = id;
        }
    }
}
