using Application.Features.Mediatr.Registers.Commands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SignalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class RegistersController : ControllerBase
	{
		private readonly IMediator _mediator;

		public RegistersController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpPost]
		public async Task<IActionResult> CreateRegister(CreateRegisterCommand command)
		{
			await _mediator.Send(command);
			return Ok("eklendi");
		}
	}
}
