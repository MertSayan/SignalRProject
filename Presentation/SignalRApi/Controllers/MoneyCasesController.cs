using Application.Features.Mediatr.MoneyCases.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoneyCasesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MoneyCasesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("GetTotalMoneyCaseAmount")]
        public async Task<IActionResult> GetTotalMoneyCaseAmount()
        {
            var values = await _mediator.Send(new GetTotalMoneyCaseAmountQuery());
            return Ok(values);
        }
    }
}
