using Application.Features.Mediatr.Logins.Commands;
using MediatR;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Application.Constants;
using Application.Tools;
using Domain;
using Application.Features.Mediatr.Logins.Queries;

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
			if (user.IsExist)
			{
				return Created("", JwtTokenGenerator.GenerateToken(user));
			}
			else
			{
				return BadRequest(Messages<User>.EntityCantMathes);
			}
		}
	}
}
