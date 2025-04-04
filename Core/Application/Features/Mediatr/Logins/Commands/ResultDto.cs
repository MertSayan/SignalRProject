using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediatr.Logins.Commands
{
	public class ResultDto
	{
		public bool Success { get; set; }
		public string Message { get; set; }

		public ResultDto(bool success, string message)
		{
			Success = success;
			Message = message;
		}
	}

}
