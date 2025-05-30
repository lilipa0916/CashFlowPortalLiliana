using CashFlowPortal.Domain.Entities;

namespace CashFlowPortal.Applicacion.Interfaces.IRepository
{
    public interface IDepositoRepository
    {
        Task AddAsync(Deposito entity);
        Task<List<Deposito>> GetAllAsync();
    }
}
