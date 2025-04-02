using Application.Constants;
using Application.Features.Mediatr.Tables.Commands;
using Application.Features.Mediatr.Tables.Queries;
using Application.Features.Mediatr.Tables.Queries;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TablesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TablesController(IMediator mediator)
        {
            _mediator = mediator;
        }

		[HttpGet]
		public async Task<IActionResult> GetAllTableList()
		{
			var values = await _mediator.Send(new GetTableQuery());
			return Ok(values);
		}
		[HttpGet("ById")]
		public async Task<IActionResult> GetByIdTable(int id)
		{
			var value = await _mediator.Send(new GetByIdTableQuery(id));
			return Ok(value);
		}

		[HttpGet("GetTableCount")]
		public async Task<IActionResult> GetTableCount()
		{
			var values = await _mediator.Send(new GetTableCountQuery());
			return Ok(values);
		}
		[HttpPost]
		public async Task<IActionResult> CreateTable(CreateTableCommand command)
		{
			await _mediator.Send(command);
			return Ok(Messages<Table>.EntityAdded);
		}
		[HttpPut]
		public async Task<IActionResult> UpdateTable(UpdateTableCommand command)
		{
			await _mediator.Send(command);
			return Ok(Messages<Table>.EntityUpdated);
		}
		[HttpDelete]
		public async Task<IActionResult> DeleteTable(int id)
		{
			await _mediator.Send(new DeleteTableCommand(id));
			return Ok(Messages<Table>.EntityDeleted);
		}

    }
}
