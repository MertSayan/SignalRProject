﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.Messages.Commands
{
	public class CreateMessageCommand:IRequest
	{
		public string NameSurname { get; set; }
		public string Mail { get; set; }
		public string Phone { get; set; }
		public string Subject { get; set; }
		public string MessageContent { get; set; }
	}
}
