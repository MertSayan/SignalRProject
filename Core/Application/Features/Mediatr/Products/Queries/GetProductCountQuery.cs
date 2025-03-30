using Application.Features.Mediatr.Products.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.Products.Queries
{
    public class GetProductCountQuery:IRequest<GetProductCountQueryResult>
    {
    }
}
