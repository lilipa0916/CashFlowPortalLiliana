using CashFlowPortal.Applicacion.Interfaces.IRepository;
using CashFlowPortal.Domain.Entities;
using CashFlowPortal.Infraestructura.Data;
using Microsoft.EntityFrameworkCore;

namespace CashFlowPortal.Infraestructura.Repositories
{
    public class GastoRepository : IGastoRepository
    {
        private readonly AppDbContext _context;
        public GastoRepository(AppDbContext context) => _context = context;

        public async Task<int> AddWithDetalleAsync(Gasto entity)
        {
            try
            {

                _context.Gastos.Add(entity);
                await _context.SaveChangesAsync();

                //// Asegúrate de que cada detalle tenga el GastoId correcto
                //foreach (var d in entity.Detalles)
                //{
                //    d.GastoId = entity.Id;
                //    _context.GastoDetalles.Add(d);
                //}

                //await _context.SaveChangesAsync();

                return entity.Id;
            }
            catch (Exception ex)
            {

                throw;
            }
            return entity.Id;
        }

        public async Task<decimal> SumByTipoAndMesAsync(Guid tipoGastoId, DateTime mes)
        {
            var start = new DateTime(mes.Year, mes.Month, 1);
            var end = start.AddMonths(1).AddTicks(-1);

            return await _context.GastoDetalles
                .Where(d => d.TipoGastoId == tipoGastoId
                         && d.Gasto.Fecha >= start
                         && d.Gasto.Fecha <= end)
                .SumAsync(d => d.Monto);
        }
    }
}
