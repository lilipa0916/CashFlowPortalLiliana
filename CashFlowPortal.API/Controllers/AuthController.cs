using CashFlowPortal.Applicacion.DTOs;
using CashFlowPortal.Infraestructura.Auth;
using Microsoft.AspNetCore.Mvc;

namespace CashFlowPortal.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IJwtTokenService _jwtService;

        public AuthController(IJwtTokenService jwtService)
        {
            _jwtService = jwtService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDto dto)
        {
            if (dto.Username == "admin" && dto.Password == "admin")
            {
                var token = _jwtService.GenerateToken("1", "admin");
                return Ok(new { Token = token });
            }

            return Unauthorized("Usuario o contraseña inválidos.");
        }
    }
}
