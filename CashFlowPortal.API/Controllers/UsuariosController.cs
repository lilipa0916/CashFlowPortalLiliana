using CashFlowPortal.Applicacion.DTOs.Auth;
using CashFlowPortal.Applicacion.Interfaces.IServices;
using CashFlowPortal.Applicacion.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace CashFlowPortal.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly IAuthService  _service;

        public UsuariosController(IAuthService service)
        {
            _service = service;
        }



        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto dto)
        {
            var result = await _service.LoginAsync(dto);

            if (result == null)
                return Unauthorized("Usuario o contraseña inválidos.");

            return Ok(result);
        }
    }
}

