using Application.Features.Mediatr.Sliders.Handlers.Read;
using Application.Features.Mediatr.Sliders.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.Sliders.Queries
{
    public class GetSliderQuery:IRequest<List<GetSliderQueryResult>>
    {
        
    }
}
