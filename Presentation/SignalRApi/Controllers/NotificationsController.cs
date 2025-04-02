using Application.Constants;
using Application.Features.Mediatr.Notifications.Commands;
using Application.Features.Mediatr.Notifications.Queries;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SignalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class NotificationsController : ControllerBase
	{
		private readonly IMediator _mediator;

		public NotificationsController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet]
		public async Task<IActionResult> GetAllNotificationList()
		{
			var values = await _mediator.Send(new GetNotificationQuery());
			return Ok(values);
		}
		[HttpGet("ById")]
		public async Task<IActionResult> GetByIdNotification(int id)
		{
			var value = await _mediator.Send(new GetByIdNotificationQuery(id));
			return Ok(value);
		}
		[HttpGet("GetNotificationCountByNotRead")]
		public async Task<IActionResult> GetNotificationCountByNotRead()
		{
			var value = await _mediator.Send(new GetNotificationCountByNotReadQuery());
			return Ok(value);
		}
		[HttpGet("GetAllNotificationByNotRead")]
		public async Task<IActionResult> GetAllNotificationByNotRead()
		{
			var value = await _mediator.Send(new GetAllNotificationByNotReadQuery());
			return Ok(value);
		}
		[HttpPost]
		public async Task<IActionResult> CreateNotification(CreateNotificationCommand command)
		{
			await _mediator.Send(command);
			return Ok(Messages<Notification>.EntityAdded);
		}
		[HttpPut]
		public async Task<IActionResult> UpdateNotification(UpdateNotificationCommand command)
		{
			await _mediator.Send(command);
			return Ok(Messages<Notification>.EntityUpdated);
		}
		[HttpGet("UpdateNotificationToRead")]
		public async Task<IActionResult> UpdateNotificationToRead(int id)
		{
			await _mediator.Send(new UpdateNotificationChangeToReadCommand(id));
			return Ok(Messages<Notification>.EntityUpdated);
		}
		[HttpGet("UpdateNotificationToNotRead")]
		public async Task<IActionResult> UpdateNotificationToNotRead(int id)
		{
			await _mediator.Send(new UpdateNotificationChangeToNotReadCommand(id));
			return Ok(Messages<Notification>.EntityUpdated);
		}
		[HttpDelete]
		public async Task<IActionResult> DeleteNotification(int id)
		{
			await _mediator.Send(new DeleteNotificationCommand(id));
			return Ok(Messages<Notification>.EntityDeleted);
		}
	}
}
