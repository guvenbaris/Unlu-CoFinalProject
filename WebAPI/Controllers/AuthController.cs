using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UnluCoProductCatalog.Application.Interfaces.ServicesInterfaces;
using UnluCoProductCatalog.Application.ViewModels.UserViewModels;

namespace WebAPI.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public  async Task<IActionResult> Register([FromBody] RegisterViewModel register)
        {
           await _authService.Register(register);

           return Ok("User registered successful");
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginViewModel login)
        {
            var token = _authService.Login(login);
            return Ok(token.Result);
        }
    }
}
