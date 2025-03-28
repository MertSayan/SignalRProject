using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.Categories.Commands
{
    public class CreateCategoryCommand:IRequest
    {
        public string CategoryName { get; set; }
        public bool CategoryStatus { get; set; }
    }
}
