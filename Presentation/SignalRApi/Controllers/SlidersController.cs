using Application.Constants;
using Application.Features.Mediatr.Sliders.Commands;
using Application.Features.Mediatr.Sliders.Queries;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SlidersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SlidersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSliderList()
        {
            var values = await _mediator.Send(new GetSliderQuery());
            return Ok(values);
        }
        [HttpGet("ById")]
        public async Task<IActionResult> GetByIdSlider(int id)
        {
            var value = await _mediator.Send(new GetByIdSliderQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateSlider(CreateSliderCommand command)
        {
            await _mediator.Send(command);
            return Ok(Messages<Slider>.EntityAdded);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateSlider(UpdateSliderCommand command)
        {
            await _mediator.Send(command);
            return Ok(Messages<Slider>.EntityUpdated);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteSlider(int id)
        {
            await _mediator.Send(new DeleteSliderCommand(id));
            return Ok(Messages<Slider>.EntityDeleted);
        }
    }
}
