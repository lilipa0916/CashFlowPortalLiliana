using CashFlowPortal.Applicacion.DTOs;
using CashFlowPortal.Applicacion.DTOs.Auth;
using CashFlowPortal.Applicacion.DTOs.Usuario;

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
