using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tourniquet.Application.Features.Auth.Commands.Login;
using Tourniquet.Application.Features.Auth.Commands.Register;

namespace Tourniquet.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AuthsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(PersonLoginCommand personForLogin)
        {
            PersonLoginCommandResponse response = await _mediator.Send(personForLogin);
            return Ok(response);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(PersonRegisterCommand personRegisterCommand)
        {
            PersonRegisterCommandResponse response = await _mediator.Send(personRegisterCommand);
            return Ok(response);
        }
    }
}