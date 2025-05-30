using CashFlowPortal.Applicacion.Interfaces.IRepository;
using CashFlowPortal.Domain.Entities;
using CashFlowPortal.Infraestructura.Data;
using Microsoft.EntityFrameworkCore;

namespace CashFlowPortal.Infraestructura.Repositories
{
    public class DepositoRepository : IDepositoRepository
    {
        private readonly AppDbContext _context;
        public DepositoRepository(AppDbContext context) => _context = context;

        public async Task AddAsync(Deposito entity)
        {
            _context.Depositos.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Deposito>> GetAllAsync()
        {
            return await _context.Depositos
                       .Include(d => d.FondoMonetario)
                       .ToListAsync();
        }
    }
}
