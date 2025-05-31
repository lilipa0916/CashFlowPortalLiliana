using CashFlowPortal.Applicacion.DTOs.Consulta;
using CashFlowPortal.Applicacion.Interfaces.IRepository;
using CashFlowPortal.Applicacion.Interfaces.IServices;

namespace CashFlowPortal.Applicacion.Services
{
    public class MovimientoService : IMovimientoService
    {
        private readonly IMovimientoRepository _repo;
        public MovimientoService(IMovimientoRepository repo) => _repo = repo;

        public Task<List<MovimientoDto>> GetMovimientosAsync(DateTime fechaDesde, DateTime fechaHasta)
            => _repo.GetMovimientosAsync(fechaDesde, fechaHasta);
    }
}
