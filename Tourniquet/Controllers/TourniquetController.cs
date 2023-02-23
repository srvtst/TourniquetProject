using BusinessLayer.Abstract;
using EntitiesLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace TourniquetAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TourniquetController : ControllerBase
    {
        ITourniquetService _tourniquetService;
        public TourniquetController(ITourniquetService tourniquetService)
        {
            _tourniquetService = tourniquetService;
        }

        [HttpPost("entry")]
        public IActionResult Entry(Tourniquet tourniquet)
        {
            var result = _tourniquetService.Entry(tourniquet);
            return Ok(result);
        }

        [HttpPut]
        public IActionResult Exit(Tourniquet tourniquet)
        {
            var result = _tourniquetService.Exit(tourniquet);
            return Ok(result);
        }

        [HttpGet("getDayTourniquet")]
        public IActionResult GetDayTourniquet(DateTime dateTime)
        {
            var result = _tourniquetService.GetDayTourniquet(dateTime);
            return Ok(result);
        }

        [HttpGet("getMonthTourniquet")]
        public IActionResult GetMonthTourniquet(DateTime dateTime)
        {
            var result = _tourniquetService.GetMonthTourniquet(dateTime);
            return Ok(result);
        }

        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            var result = _tourniquetService.GetAll();
            return Ok(result);
        }

        [HttpGet("getByTourniquet")]
        public IActionResult GetByTourniquet(int id)
        {
            var result = _tourniquetService.GetByTourniquet(id);
            return Ok(result);
        }
    }
}