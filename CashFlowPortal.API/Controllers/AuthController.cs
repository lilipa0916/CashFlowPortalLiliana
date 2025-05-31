using CashFlowPortal.Applicacion.DTOs.Auth;
using CashFlowPortal.Applicacion.Interfaces.IServices;
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
        public IActionResult Login([FromBody] LoginRequestDto dto)
        {
            if (dto.Usuario == "admin" && dto.Clave == "admin")
            {
                var token = _jwtService.GenerateToken(dto);
                return Ok(new { Token = token });
            }

            return Unauthorized("Usuario o contraseña inválidos.");
        }
    }
}
