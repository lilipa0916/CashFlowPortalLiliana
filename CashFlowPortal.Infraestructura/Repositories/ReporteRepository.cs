using CashFlowPortal.Applicacion.DTOs.Reporte;
using CashFlowPortal.Applicacion.Interfaces.IRepository;
using CashFlowPortal.Infraestructura.Data;
using Microsoft.EntityFrameworkCore;

namespace CashFlowPortal.Infraestructura.Repositories
{
    public class ReporteRepository : IReporteRepository
    {
        private readonly AppDbContext _context;
        public ReporteRepository(AppDbContext context) => _context = context;

        public async Task<List<PresupuestoEjecucionDto>> GetComparativoAsync(DateTime desde, DateTime hasta)
        {
            var presupuestos = await _context.Presupuestos
                .Where(p => p.Mes >= desde && p.Mes <= hasta)
                .GroupBy(p => p.TipoGastoId)
                .Select(g => new {
                    TipoGastoId = g.Key,
                    TotalPresupuesto = g.Sum(x => x.Monto)
                }).ToListAsync();

            var ejecutados = await _context.GastoDetalles
                .Include(d => d.Gasto)
                .Where(d => d.Gasto.Fecha >= desde && d.Gasto.Fecha <= hasta)
                .GroupBy(d => d.TipoGastoId)
                .Select(g => new {
                    TipoGastoId = g.Key,
                    TotalEjecutado = g.Sum(d => d.Monto)
                }).ToListAsync();

            var query = from p in presupuestos
                        join e in ejecutados on p.TipoGastoId equals e.TipoGastoId into ej
                        from e in ej.DefaultIfEmpty()
                        join t in _context.TiposGasto on p.TipoGastoId equals t.Id
                        select new PresupuestoEjecucionDto
                        {
                            TipoGasto = t.Nombre,
                            Presupuestado = p.TotalPresupuesto,
                            Ejecutado = e != null ? e.TotalEjecutado : 0
                        };

            return  query.ToList();
        }
    }
}
