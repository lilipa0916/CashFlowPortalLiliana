using CashFlowPortal.Applicacion.DTOs;
using CashFlowPortal.Applicacion.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CashFlowPortal.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TipoGastoController : ControllerBase
    {
        private readonly ITipoGastoService _service;

        public TipoGastoController(ITipoGastoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TipoGastoDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var id = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetAll), new { id }, null);
        }
    }
}
