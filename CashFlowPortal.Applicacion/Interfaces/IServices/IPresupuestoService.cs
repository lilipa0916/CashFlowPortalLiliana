using CashFlowPortal.Applicacion.DTOs.Presupuesto;

namespace CashFlowPortal.Applicacion.Interfaces.IServices
{
    public interface IPresupuestoService
    {
        Task<List<PresupuestoDto>> GetByMesAsync(Guid usuarioId, DateTime mes);
        Task AddOrUpdateAsync(PresupuestoDto dto);
    }
}
