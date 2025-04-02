using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRDto.IdentityDtos
{
	public class CreateLoginDto
	{
		public string UserName { get; set; }
		public string Password { get; set; }
	}
}
