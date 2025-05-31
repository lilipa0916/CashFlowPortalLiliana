using CashFlowPortal.Applicacion.DTOs.Auth;
using CashFlowPortal.Domain.Entities;

namespace CashFlowPortal.Applicacion.Interfaces.IRepository
{
    public interface IAuthRepository
    {
        //Task<LoginResponseDto> LoginAsync(Usuario request);

        Task<Usuario?> LoginAsync(LoginRequestDto request);
    }
}
