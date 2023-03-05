using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tourniquet.Application.Features.Commands.Remove;
using Tourniquet.Application.Features.Commands.Update;
using Tourniquet.Application.Features.Queries.GetAllPersons;

namespace Tourniquet.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly IMediator _mediatr;
        public PersonsController(IMediator mediatr)
        {
            _mediatr = mediatr;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllPersonQueryCommand getAllPersonQueryCommand)
        {
            var response = await _mediatr.Send(getAllPersonQueryCommand);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdatedPersonCommand updatedPerson)
        {
            UpdatedPersonResponse response = await _mediatr.Send(updatedPerson);
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(RemovePersonCommand removePerson)
        {
            RemovePersonResponse response = await _mediatr.Send(removePerson);
            return Ok(response);
        }
    }
}