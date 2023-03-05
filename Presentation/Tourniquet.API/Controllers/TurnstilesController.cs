using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tourniquet.Application.Features.Tourniquet.Commands.Create;
using Tourniquet.Application.Features.Tourniquet.Commands.Update;
using Tourniquet.Application.Features.Tourniquet.Queries.GetAllTourniquet;
using Tourniquet.Application.Features.Tourniquet.Queries.GetDayTourniquet;
using Tourniquet.Application.Features.Tourniquet.Queries.GetMonthTourniquet;

namespace Tourniquet.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurnstilesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TurnstilesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetAllTurnstileQueryCommand getAllTurnstile)
        {
            var response = await _mediator.Send(getAllTurnstile);
            return Ok(response);
        }

        [HttpGet("getDay")]
        public async Task<IActionResult> GetDayTurnstile([FromQuery] GetDayTurnstileQueryCommand getDayTurnstileQueryCommand)
        {
            var response = await _mediator.Send(getDayTurnstileQueryCommand);
            return Ok(response);
        }

        [HttpGet("getMonth")]
        public async Task<IActionResult> GetMontTurnstile([FromQuery] GetMonthTurnstileQueryCommand getMonthTurnstileQueryCommand)
        {
            var response = await _mediator.Send(getMonthTurnstileQueryCommand);
            return Ok(response);
        }

        [HttpPost("entry")]
        public async Task<IActionResult> Add([FromBody] CreatedTurnstileCommand createdTurnstile)
        {
            CreatedTurnstileResponse response = await _mediator.Send(createdTurnstile);
            return Ok(response);
        }

        [HttpPost("exit")]
        public async Task<IActionResult> Exit([FromBody] UpdatedTurnstileCommand updatedTurnstileCommand)
        {
            UpdatedTurnstileResponse response = await _mediator.Send(updatedTurnstileCommand);
            return Ok(response);
        }
    }
}