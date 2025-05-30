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
            try
            {
                _context.TiposGasto.Add(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw;
            }

            return entity;
        }

        public async Task<List<TipoGasto>> GetAllAsync()
        {
            return await _context.TiposGasto.ToListAsync();
        }

        public async Task<TipoGasto?> GetByIdAsync(Guid id)
        {
            return await _context.TiposGasto.FindAsync(id);
        }

        public async Task UpdateAsync(TipoGasto entity)
        {
            try
            {
                _context.TiposGasto.Update(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw;
            }

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
            // 1. Traemos todas las partes numéricas como string (sin "TG") al cliente
            var codigos = await _context.TiposGasto
                .Where(x => x.Codigo != null && x.Codigo.StartsWith("TG"))
                .Select(x => x.Codigo!.Substring(2))
                .ToListAsync();

            // 2. Parseamos cada string a int (si falla, lo convertimos en 0)
            var numeros = codigos
                .Select(s => int.TryParse(s, out var n) ? n : 0);

            // 3. Obtenemos el máximo (o 0 si no hay ninguno) y sumamos 1
            var maxNumero = numeros.DefaultIfEmpty(0).Max();
            var siguiente = maxNumero + 1;

            return $"TG{siguiente:D3}";
        }
    }
}
