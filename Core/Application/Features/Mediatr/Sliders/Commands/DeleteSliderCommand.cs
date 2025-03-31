using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.Sliders.Commands
{
    public class DeleteSliderCommand:IRequest
    {
        public int Id { get; set; }

        public DeleteSliderCommand(int id)
        {
            Id = id;
        }
    }
}
