﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.Tables.Commands
{
    public class UpdateTableCommand:IRequest
    {
		public int TableId { get; set; }
		public string Name { get; set; }
		public bool Status { get; set; }
	}
}
