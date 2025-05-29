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
        Task<FondoMonetarioDto> CreateAsync(CreateFondoMonetarioDto dto);
        Task<IEnumerable<FondoMonetarioDto>> GetAllAsync();
        Task<FondoMonetarioDto?> GetByIdAsync(Guid id);
        Task UpdateAsync(Guid id, CreateFondoMonetarioDto dto);
        Task DeleteAsync(Guid id);
    }
}
