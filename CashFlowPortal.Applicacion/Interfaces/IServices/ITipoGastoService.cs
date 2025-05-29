using CashFlowPortal.Applicacion.DTOs.TipoGasto;

namespace CashFlowPortal.Applicacion.Interfaces.IServices
{
    public interface ITipoGastoService
    {
        Task<TipoGastoDto> CreateAsync(TipoGastoDto dto);
        Task CreateAsync(CreateTipoGastoDto dto);
        Task<IEnumerable<TipoGastoDto>> GetAllAsync();
        Task<TipoGastoDto> GetByIdAsync(Guid id);
        Task UpdateAsync(UpdateTipoGastoDto dto);
        Task DeleteAsync(Guid id);
    }
}
