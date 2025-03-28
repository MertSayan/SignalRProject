using Application.Features.Mediatr.Testimonials.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.Testimonials.Queries
{
    public class GetByIdTestimonialQuery:IRequest<GetByIdTestimonialQueryResult>
    {
        public int Id { get; set; }

        public GetByIdTestimonialQuery(int id)
        {
            Id = id;
        }
    }
}
