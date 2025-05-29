using CashFlowPortal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashFlowPortal.Applicacion.Interfaces.IRepository
{
    public interface IFondoMonetarioRepository
    {
        Task<FondoMonetario> AddAsync(FondoMonetario entity);
        Task<IEnumerable<FondoMonetario>> GetAllAsync();
        Task<FondoMonetario?> GetByIdAsync(Guid id);
        Task UpdateAsync(FondoMonetario entity);
        Task DeleteAsync(Guid id);
    }
}
