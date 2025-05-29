using CashFlowPortal.Applicacion.DTOs.TipoGasto;

namespace CashFlowPortal.Applicacion.Interfaces.IServices
{
    public interface ITipoGastoService
    {
        Task<TipoGastoDto> CreateAsync(TipoGastoDto dto);
        Task CreateAsync(TipoGastoFormDto dto);
        Task<IEnumerable<TipoGastoDto>> GetAllAsync();
        Task<TipoGastoDto> GetByIdAsync(Guid id);
        Task UpdateAsync(TipoGastoFormDto dto);
        Task DeleteAsync(Guid id);
    }
}
