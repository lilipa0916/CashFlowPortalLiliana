using CashFlowPortal.Applicacion.DTOs;
using CashFlowPortal.Applicacion.Interfaces;
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

        [HttpGet]
        public async Task<IActionResult> Get() =>
            Ok(await _service.GetAllAsync());

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UsuarioDto dto)
        {
            await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(Get), new { id = dto.Id }, dto);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UsuarioDto dto) =>
            Ok(await _service.LoginAsync(dto.UsuarioLogin, dto.Password));
    }
}
