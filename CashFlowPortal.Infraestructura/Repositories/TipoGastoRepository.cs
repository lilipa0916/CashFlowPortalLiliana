using CashFlowPortal.Domain.Entities;
using CashFlowPortal.Infraestructura.Data;
using Microsoft.EntityFrameworkCore;

namespace CashFlowPortal.Infraestructura.Repositories
{
    public class TipoGastoRepository
    {
        private readonly AppDbContext _context;

        public TipoGastoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TipoGasto>> GetAllAsync()
            => await _context.TiposGasto.ToListAsync();

        public async Task<TipoGasto?> GetByIdAsync(Guid id)
            => await _context.TiposGasto.FindAsync(id);

        public async Task AddAsync(TipoGasto tipoGasto)
        {
            _context.TiposGasto.Add(tipoGasto);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TipoGasto tipoGasto)
        {
            _context.TiposGasto.Update(tipoGasto);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var tipo = await _context.TiposGasto.FindAsync(id);
            if (tipo is not null)
            {
                _context.TiposGasto.Remove(tipo);
                await _context.SaveChangesAsync();
            }
        }
    }
}
