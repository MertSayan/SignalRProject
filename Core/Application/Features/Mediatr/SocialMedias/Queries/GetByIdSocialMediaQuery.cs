using Application.Features.Mediatr.SocialMedias.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.SocialMedias.Queries
{
    public class GetByIdSocialMediaQuery:IRequest<GetByIdSocialMediaQueryResult>
    {
        public int Id { get; set; }

        public GetByIdSocialMediaQuery(int id)
        {
            Id = id;
        }
    }
}
