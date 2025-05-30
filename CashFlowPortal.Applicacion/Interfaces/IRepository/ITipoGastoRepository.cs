using CashFlowPortal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashFlowPortal.Applicacion.Interfaces.Repository
{
    public interface ITipoGastoRepository
    {
        Task<TipoGasto> AddAsync(TipoGasto entity);
        Task<List<TipoGasto>> GetAllAsync();
        Task<TipoGasto?> GetByIdAsync(Guid id);
        Task UpdateAsync(TipoGasto entity);
        Task DeleteAsync(Guid id);
        Task<string> GenerarCodigoAsync();

    }
}
