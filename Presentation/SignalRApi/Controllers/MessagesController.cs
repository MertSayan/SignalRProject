using Application.Constants;
using Application.Features.Mediatr.Messages.Commands;
using Application.Features.Mediatr.Messages.Queries;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SignalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MessagesController : ControllerBase
	{
		private readonly IMediator _mediator;

		public MessagesController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet]
		public async Task<IActionResult> GetAllMessageList()
		{
			var values = await _mediator.Send(new GetMessageQuery());
			return Ok(values);
		}
		[HttpGet("ById")]
		public async Task<IActionResult> GetByIdMessage(int id)
		{
			var value = await _mediator.Send(new GetByIdMessageQuery(id));
			return Ok(value);
		}
		[HttpPost]
		public async Task<IActionResult> CreateMessage(CreateMessageCommand command)
		{
			await _mediator.Send(command);
			return Ok(Messages<Message>.EntityAdded);
		}
		[HttpPut]
		public async Task<IActionResult> UpdateMessage(UpdateMessageCommand command)
		{
			await _mediator.Send(command);
			return Ok(Messages<Message>.EntityUpdated);
		}
		[HttpDelete]
		public async Task<IActionResult> DeleteMessage(int id)
		{
			await _mediator.Send(new DeleteMessageCommand(id));
			return Ok(Messages<Message>.EntityDeleted);
		}
	}
}
