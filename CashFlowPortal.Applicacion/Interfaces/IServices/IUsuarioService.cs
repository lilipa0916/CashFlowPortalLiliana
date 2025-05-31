using CashFlowPortal.Applicacion.DTOs.Auth;

namespace CashFlowPortal.Applicacion.Interfaces.Services
{
    public interface IUsuarioService
    {
        public interface IUsuarioService
        {
            Task<LoginResponseDto?> LoginAsync(LoginRequestDto request);
        }

    }
}
