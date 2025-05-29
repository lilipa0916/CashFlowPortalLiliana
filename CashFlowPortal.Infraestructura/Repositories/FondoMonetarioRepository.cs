using CashFlowPortal.Applicacion.Interfaces.IRepository;
using CashFlowPortal.Domain.Entities;
using CashFlowPortal.Infraestructura.Data;
using Microsoft.EntityFrameworkCore;

namespace CashFlowPortal.Infraestructura.Repositories
{
    public class FondoMonetarioRepository : IFondoMonetarioRepository
    {
        private readonly AppDbContext _context;
        public FondoMonetarioRepository(AppDbContext context) => _context = context;

        public async Task<FondoMonetario> AddAsync(FondoMonetario entity)
        {
            await _context.Fondos.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(Guid id)
        {
            var e = await _context.Fondos.FindAsync(id);
            if (e != null)
            {
                _context.Fondos.Remove(e);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<FondoMonetario>> GetAllAsync()
            => await _context.Fondos.AsNoTracking().ToListAsync();

        public async Task<FondoMonetario?> GetByIdAsync(Guid id)
            => await _context.Fondos.FindAsync(id);

        public async Task UpdateAsync(FondoMonetario entity)
        {
            _context.Fondos.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
