using CashFlowPortal.Applicacion.DTOs.FondoMonetario;
using CashFlowPortal.Applicacion.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;

namespace CashFlowPortal.API.Controllers
{
    /// <summary>
    /// El fondo familiar que puede ser cuentas bancarias, fondos de caja menor, ahorros...
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class FondoMonetarioController : Controller
    {
        private readonly IFondoMonetarioService _service;
        public FondoMonetarioController(IFondoMonetarioService services) => _service = services;

        /// <summary>
        /// Consulta todos los fondos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await _service.GetAllAsync());

        /// <summary>
        /// Consulta un fondo por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id) => Ok(await _service.GetByIdAsync(id));

        /// <summary>
        /// Crea un fondo monetario
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] FondoMonetarioDto dto)
        {
            var created = await _service.CreateAsync(dto);
            return Ok();
        }

        /// <summary>
        /// Actualiza un fondo monetario
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] FondoMonetarioDto dto)
        {
            dto.Id = id;
            await _service.UpdateAsync(id, dto);
            return NoContent();
        }

        /// <summary>
        /// Borra un fondo monetario
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }


    }
}
