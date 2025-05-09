﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.Logins.Commands
{
	public class LoginCommand:IRequest<ResultDto>
	{

		public string Username { get; set; }
		public string Password { get; set; }
	}
}
