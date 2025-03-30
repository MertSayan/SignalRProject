using Application.Features.Mediatr.Tables.Queries;
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

        [HttpGet("GetTableCount")]
        public async Task<IActionResult> GetTableCount()
        {
            var values=await _mediator.Send(new GetTableCountQuery());
            return Ok(values);
        }
    }
}
