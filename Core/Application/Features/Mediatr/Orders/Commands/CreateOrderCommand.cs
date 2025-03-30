using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.Orders.Commands
{
    public class CreateOrderCommand:IRequest
    {
        public int OrderId { get; set; }
        public string TableNumber { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
