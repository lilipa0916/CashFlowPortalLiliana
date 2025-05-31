using AutoMapper;
using CashFlowPortal.Applicacion.DTOs.Auth;
using CashFlowPortal.Applicacion.DTOs.Deposito;
using CashFlowPortal.Applicacion.Interfaces.IRepository;
using CashFlowPortal.Applicacion.Interfaces.IServices;
using CashFlowPortal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashFlowPortal.Applicacion.Services
{
    public class AuthService : IAuthService
    {

        private readonly IAuthRepository _repo;
        private readonly IMapper _mapper;
        public AuthService(IAuthRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<LoginResponseDto> LoginAsync(LoginRequestDto request)
        {
            var dtos = _mapper.Map<Usuario>(request);
            return await _repo.LoginAsync(dtos);
        }

       

    }
}
