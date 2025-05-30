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
        Task AddAsync(FondoMonetario entity);
        Task<List<FondoMonetario>> GetAllAsync();
        Task<FondoMonetario?> GetByIdAsync(int id);
        Task UpdateAsync(FondoMonetario entity);
        Task DeleteAsync(int id);
    }
}
