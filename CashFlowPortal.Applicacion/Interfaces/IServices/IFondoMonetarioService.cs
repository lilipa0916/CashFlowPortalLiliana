using CashFlowPortal.Applicacion.DTOs.FondoMonetario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashFlowPortal.Applicacion.Interfaces.IServices
{
    public interface IFondoMonetarioService
    {
        Task<int> CreateAsync(FondoMonetarioDto dto);
        Task<List<FondoMonetarioDto>> GetAllAsync();
        Task<FondoMonetarioDto?> GetByIdAsync(int id);
        Task UpdateAsync(int id, FondoMonetarioDto dto);
        Task DeleteAsync(int id);
    }
}
