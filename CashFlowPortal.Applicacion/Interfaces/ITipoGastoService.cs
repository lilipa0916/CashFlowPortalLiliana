using CashFlowPortal.Applicacion.DTOs;

namespace CashFlowPortal.Applicacion.Interfaces
{
    public interface ITipoGastoService
    {
        Task<IEnumerable<TipoGastoDto>> GetAllAsync();
        Task<TipoGastoDto?> GetByIdAsync(Guid id);
        Task<bool> CreateAsync(TipoGastoDto dto);
        Task<bool> UpdateAsync(TipoGastoDto dto);
        Task<bool> DeleteAsync(Guid id);
    }
}
