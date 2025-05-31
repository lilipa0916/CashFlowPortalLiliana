using CashFlowPortal.Applicacion.DTOs.Auth;

namespace CashFlowPortal.Applicacion.Interfaces.IServices
{
    public interface IJwtTokenService
    {
        string GenerateToken(LoginRequestDto user);
    }
}
