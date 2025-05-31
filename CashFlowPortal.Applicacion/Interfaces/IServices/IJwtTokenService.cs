using CashFlowPortal.Applicacion.DTOs.Auth;
using CashFlowPortal.Domain.Entities;

namespace CashFlowPortal.Applicacion.Interfaces.IServices
{
    public interface IJwtTokenService
    {
        //string GenerateToken(LoginRequestDto user);
        string GenerateToken(Usuario user);

        //string GenerateToken(LoginRequestDto useLog);
    }
}
