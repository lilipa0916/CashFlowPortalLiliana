using CashFlowPortal.Applicacion.DTOs.Deposito;

namespace CashFlowPortal.Applicacion.Interfaces.IServices
{
    public interface IDepositoService
    {
        Task CreateAsync(DepositoDto dto);
        Task<List<DepositoDto>> GetAllAsync();
    }
}
