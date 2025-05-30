using CashFlowPortal.Applicacion.Interfaces.IRepository;
using CashFlowPortal.Domain.Entities;
using CashFlowPortal.Infraestructura.Data;
using Microsoft.EntityFrameworkCore;

namespace CashFlowPortal.Infraestructura.Repositories
{
    public class PresupuestoRepository : IPresupuestoRepository
    {
        private readonly AppDbContext _context;
        public PresupuestoRepository(AppDbContext context) => _context = context;

        public async Task<Presupuesto?> GetByIdAsync(Guid id)
            => await _context.Presupuestos
                             .Include(p => p.TipoGasto)
                             .Include(p => p.Detalles)
                             .FirstOrDefaultAsync(p => p.Id == id);

        public async Task<List<Presupuesto>> GetByMesAsync(Guid usuarioId, DateTime mes)
            => await _context.Presupuestos
                             .Where(p => p.UsuarioId == usuarioId &&
                                         p.Mes.Year == mes.Year &&
                                         p.Mes.Month == mes.Month)
                             .Include(p => p.TipoGasto)
                             .ToListAsync();

        public async Task AddOrUpdateAsync(Presupuesto entity)
        {
            try
            {


                var existing = await _context.Presupuestos
                    .Include(p => p.Detalles)
                    .FirstOrDefaultAsync(p =>
                        p.UsuarioId == entity.UsuarioId &&
                        p.Mes.Year == entity.Mes.Year &&
                        p.Mes.Month == entity.Mes.Month);

                if (existing == null)
                {
                    _context.Presupuestos.Add(entity);
                }
                else
                {
                    // Actualiza campos del encabezado
                    existing.TipoGastoId = entity.TipoGastoId;
                    existing.Monto = entity.Monto;

                    // Reemplaza detalles
                    _context.PresupuestoDetalle.RemoveRange(existing.Detalles);
                    foreach (var detalle in entity.Detalles)
                    {
                        detalle.PresupuestoId = existing.Id;
                        _context.PresupuestoDetalle.Add(detalle);
                    }

                    _context.Presupuestos.Update(existing);
                }

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
