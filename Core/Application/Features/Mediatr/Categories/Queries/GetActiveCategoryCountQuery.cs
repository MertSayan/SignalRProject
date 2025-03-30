using Application.Features.Mediatr.Categories.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.Categories.Queries
{
    public class GetActiveCategoryCountQuery:IRequest<GetActiveCategoryCountQueryResult>
    {
    }
}
