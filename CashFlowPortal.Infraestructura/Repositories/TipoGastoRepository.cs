using CashFlowPortal.Applicacion.Interfaces.Repository;
using CashFlowPortal.Domain.Entities;
using CashFlowPortal.Infraestructura.Data;
using Microsoft.EntityFrameworkCore;

namespace CashFlowPortal.Infraestructura.Repositories
{
    public class TipoGastoRepository : ITipoGastoRepository
    {
        private readonly AppDbContext _context;

        public TipoGastoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<TipoGasto> AddAsync(TipoGasto entity)
        {
            _context.TiposGasto.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<TipoGasto>> GetAllAsync()
        {
            return await _context.TiposGasto.ToListAsync();
        }

        public async Task<TipoGasto?> GetByIdAsync(Guid id)
        {
            return await _context.TiposGasto.FindAsync(id);
        }

        public async Task UpdateAsync(TipoGasto entity)
        {
            _context.TiposGasto.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await _context.TiposGasto.FindAsync(id);
            if (entity != null)
            {
                _context.TiposGasto.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<string> GenerarCodigoAsync()
        {
            var ultimo = await _context.TiposGasto
                .OrderByDescending(x => x.Id)
                .FirstOrDefaultAsync();

            int secuencia = (ultimo != null && int.TryParse(ultimo.Codigo?.Substring(2), out var n)) ? n + 1 : 1;
            return $"TG{secuencia:D3}";
        }
    }
}
