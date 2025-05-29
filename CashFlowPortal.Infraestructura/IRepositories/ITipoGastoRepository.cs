using CashFlowPortal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashFlowPortal.Infraestructura.IRepositories
{
    public interface ITipoGastoRepository
    {
        Task<TipoGasto> AddAsync(TipoGasto entity);
        Task<IEnumerable<TipoGasto>> GetAllAsync();
        Task<TipoGasto> GetByIdAsync(int id);
        Task UpdateAsync(TipoGasto entity);
        Task DeleteAsync(int id);
        Task<string> GenerarCodigoAsync();
    }
}
