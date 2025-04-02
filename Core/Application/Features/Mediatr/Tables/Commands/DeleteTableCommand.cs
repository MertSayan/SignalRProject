using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.Tables.Commands
{
    public class DeleteTableCommand:IRequest
    {
        public int Id { get; set; }

		public DeleteTableCommand(int id)
		{
			Id = id;
		}
	}
}
