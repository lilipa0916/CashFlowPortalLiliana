using CashFlowPortal.Applicacion.DTOs.Auth;
using CashFlowPortal.Applicacion.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace CashFlowPortal.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioService _service;

        public UsuariosController(IUsuarioService service)
        {
            _service = service;
        }



        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto dto) => Ok();
            //Ok(await _service.LoginAsync(dto));
    }
}

// Task<LoginResponseDto?> LoginAsync(LoginRequestDto request)