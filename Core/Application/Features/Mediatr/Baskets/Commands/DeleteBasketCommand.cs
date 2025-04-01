using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.Baskets.Commands
{
    public class DeleteBasketCommand:IRequest
    {
        public int Id { get; set; }

        public DeleteBasketCommand(int id)
        {
            Id = id;
        }
    }
}
