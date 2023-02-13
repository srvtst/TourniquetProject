using BusinessLayer.Abstract;
using EntitiesLayer.Concrete;
using EntitiesLayer.Dto;
using Microsoft.AspNetCore.Mvc;

namespace TourniquetAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;
        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpPost]
        public IActionResult Add(Person person)
        {
            _personService.Add(person);
            return Ok();
        }

        [HttpPut]
        public IActionResult Update(PersonUpdate personUpdate)
        {
            var result = _personService.Update(personUpdate);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _personService.Delete(id);
            return Ok(result);
        }

        [HttpGet("{email}")]
        public IActionResult GetByEmail(string email)
        {
            var result = _personService.GetByEmail(email);
            return Ok(result);
        }
    }
}