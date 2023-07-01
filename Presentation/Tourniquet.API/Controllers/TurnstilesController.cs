using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tourniquet.Application.Features.Tourniquet.Commands.Create;
using Tourniquet.Application.Features.Tourniquet.Commands.Remove;
using Tourniquet.Application.Features.Tourniquet.Commands.Update;
using Tourniquet.Application.Features.Tourniquet.Queries.GetAllTourniquet;
using Tourniquet.Application.Features.Tourniquet.Queries.GetByIdTourniquet;
using Tourniquet.Application.Features.Tourniquet.Queries.GetDayTourniquet;
using Tourniquet.Application.Features.Tourniquet.Queries.GetMonthTourniquet;
using Tourniquet.Application.Features.Tourniquet.Queries.GetQueueTourniquet;

namespace Tourniquet.API.Controllers
{
    [Route("api/[controller]/[action]")]
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

        [HttpGet()]
        public async Task<IActionResult> GetById([FromQuery] GetByIdTurnstileQueryCommand getByIdTurnstileQueryCommand)
        {
            var response = await _mediator.Send(getByIdTurnstileQueryCommand);
            return Ok(response);
        }

        [HttpGet()]
        public async Task<IActionResult> GetDayTurnstile([FromQuery] GetDayTurnstileQueryCommand getDayTurnstileQueryCommand)
        {
            var response = await _mediator.Send(getDayTurnstileQueryCommand);
            return Ok(response);
        }

        [HttpGet()]
        public async Task<IActionResult> GetMonthTurnstile([FromQuery] GetMonthTurnstileQueryCommand getMonthTurnstileQueryCommand)
        {
            var response = await _mediator.Send(getMonthTurnstileQueryCommand);
            return Ok(response);
        }

        [HttpGet()]
        public async Task<IActionResult> GetQueueTurnstile([FromQuery] GetQueueTurnstileQueryCommand getQueueTurnstileQueryCommand)
        {
            var response = await _mediator.Send(getQueueTurnstileQueryCommand);
            return Ok(response);
        }

        [HttpPost()]
        public async Task<IActionResult> EntryTurnstile([FromBody] CreatedTurnstileCommand createdTurnstile)
        {
            CreatedTurnstileResponse response = await _mediator.Send(createdTurnstile);
            return Ok(response);
        }

        [HttpPost()]
        public async Task<IActionResult> ExitTurnstile([FromBody] UpdatedTurnstileCommand updatedTurnstileCommand)
        {
            UpdatedTurnstileResponse response = await _mediator.Send(updatedTurnstileCommand);
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteTurnstile([FromBody] RemoveTurnstileCommand removeTurnstileCommand)
        {
            RemoveTurnstileResponse response = await _mediator.Send(removeTurnstileCommand);
            return Ok(response);
        }
    }
}