using Application.Constants;
using Application.Features.Mediatr.Logins.Commands;
using Application.Features.Mediatr.Logins.Queries;
using Application.Features.Mediatr.Registers.Commands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SignalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class LoginsController : ControllerBase
	{
		private readonly IMediator _mediator;

		public LoginsController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpPost]
		public async Task<IActionResult> Index(GetUserByUserNameAndPasswordQuery query)
		{
			var user = await _mediator.Send(query);
			return Ok(user);
		}

	}
}
