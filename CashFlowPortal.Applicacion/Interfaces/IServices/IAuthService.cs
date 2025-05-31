using CashFlowPortal.Applicacion.DTOs.Auth;
using CashFlowPortal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashFlowPortal.Applicacion.Interfaces.IServices
{
    public interface IAuthService
    {
     
        Task<LoginResponseDto> LoginAsync(LoginRequestDto request);
    }
}
