using CashFlowPortal.Applicacion.DTOs.TipoGasto;

namespace CashFlowPortal.Applicacion.Interfaces.IServices
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
