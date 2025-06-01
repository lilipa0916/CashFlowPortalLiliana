using CashFlowPortal.Domain.Entities;

namespace CashFlowPortal.Applicacion.Interfaces.IRepository
{
    public interface IPresupuestoRepository
    {
        /// <summary>
        /// Obtiene todos los presupuestos de un usuario en un mes específico.
        /// </summary>
        Task<List<Presupuesto>> GetByMesAsync(Guid usuarioId, DateTime mes);

       

        /// <summary>
        /// Crea o actualiza un presupuesto (y sus detalles) según exista o no.
        /// </summary>
        Task AddOrUpdateAsync(Presupuesto entity);
    }
}
