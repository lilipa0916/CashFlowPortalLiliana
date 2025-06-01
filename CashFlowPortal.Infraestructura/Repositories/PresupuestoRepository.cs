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

        public async Task<List<Presupuesto>> GetByMesAsync(Guid usuarioId, DateTime mes)
            => await _context.Presupuestos
                             .Where(p => p.UsuarioId == usuarioId &&
                                         p.Mes.Year == mes.Year &&
                                         p.Mes.Month == mes.Month)
                             .Include(p => p.TipoGasto)
                             .ToListAsync();

        public async Task AddOrUpdateAsync(Presupuesto entity)
        {

                var existing = await _context.Presupuestos
                    .FirstOrDefaultAsync(p =>
                        p.UsuarioId == entity.UsuarioId &&
                        p.TipoGastoId == entity.TipoGastoId &&
                        p.Mes.Year == entity.Mes.Year &&
                        p.Mes.Month == entity.Mes.Month);

                if (existing == null)
                {
                    _context.Presupuestos.Add(entity);
                }
                else
                {
                    existing.Monto = entity.Monto;
                    //existing.TipoGastoId = entity.TipoGastoId;
                    _context.Presupuestos.Update(existing);
                }

                await _context.SaveChangesAsync();

        }
    }
}
