using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.Logins.Results
{
	public class GetUserByUserNameAndPasswordQueryResult
	{
		public int UserId { get; set; }
		public string RoleName { get; set; }
		public bool IsExist { get; set; }
	}
}
