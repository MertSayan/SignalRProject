﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.Logins.Results
{
	public class GetUserByUserNameAndPasswordQueryResult
	{
		public string Name { get; set; }
		public string Surname { get; set; }
		public string Username { get; set; }
		public string Mail { get; set; }
		public string Password { get; set; }
	}
}
