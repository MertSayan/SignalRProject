using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.Discounts.Commands
{
    public class DeleteDiscountCommand:IRequest
    {
        public int Id { get; set; }

        public DeleteDiscountCommand(int id)
        {
            Id = id;
        }
    }
}
