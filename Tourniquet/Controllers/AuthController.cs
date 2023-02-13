using BusinessLayer.Abstract;
using CoreLayer.Security.Jwt;
using EntitiesLayer.Dto;
using Microsoft.AspNetCore.Mvc;

namespace TourniquetAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly ITokenHelper _tokenHelper;
        public AuthController(IAuthService autService,ITokenHelper tokenHelper)
        {
            _authService = autService;
            _tokenHelper = tokenHelper;
        }

        [HttpPost("login")]
        public IActionResult Login(PersonForLogin personForLogin)
        {
            _authService.Login(personForLogin);
            var result = _tokenHelper.CreateToken();
            return Ok(result);
        }

        [HttpPost("register")]
        public IActionResult Register(PersonCreateAndRegister personCreateAndRegister)
        {
            _authService.Register(personCreateAndRegister);
            var result = _tokenHelper.CreateToken();
            return Ok(result);
        }
    }
}