using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.Testimonials.Commands
{
    public class DeleteTestimonialCommand:IRequest
    {
        public int Id { get; set; }

        public DeleteTestimonialCommand(int id)
        {
            Id = id;
        }
    }
}
