using CashFlowPortal.Applicacion.DTOs.Auth;
using CashFlowPortal.Applicacion.Interfaces.IServices;
using CashFlowPortal.Applicacion.Interfaces.Services;
using CashFlowPortal.Applicacion.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CashFlowPortal.Web.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _usuarioService;

        public AuthController(IAuthService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequestDto dto)
        {
            // lógica para autenticar
            var usuario = _usuarioService.LoginAsync(dto);
            if (usuario == null)
                return BadRequest("Credenciales inválidas");

            // generar token
            var token = "tu_token_generado";
            return Ok(new LoginResponseDto { Token = token });
        }
    }
}
