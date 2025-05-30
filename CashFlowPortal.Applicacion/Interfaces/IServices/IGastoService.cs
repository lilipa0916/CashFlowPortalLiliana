using CashFlowPortal.Applicacion.DTOs.Gasto;

namespace CashFlowPortal.Applicacion.Interfaces.IServices
{
    public interface IGastoService
    {
        Task<int> CreateAsync(GastoDto dto);
    }
}
