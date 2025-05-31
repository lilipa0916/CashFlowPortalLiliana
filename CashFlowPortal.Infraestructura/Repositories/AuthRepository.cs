using AutoMapper;
using CashFlowPortal.Applicacion.DTOs.Auth;
using CashFlowPortal.Applicacion.Interfaces.IRepository;
using CashFlowPortal.Applicacion.Interfaces.IServices;
using CashFlowPortal.Domain.Entities;
using CashFlowPortal.Infraestructura.Data;
using CashFlowPortal.Infraestructura.Seguridad;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashFlowPortal.Infraestructura.Repositories
{
    public class AuthRepository: IAuthRepository
    {
        private readonly AppDbContext _context; // o bien IApplicationDbContext
        private readonly IJwtTokenService _jwtTokenService;
        private readonly IMapper _mapper;

        public AuthRepository(AppDbContext context, IJwtTokenService jwtTokenService, IMapper mapper)
        {
            _context = context;
            _jwtTokenService = jwtTokenService;
            _mapper = mapper;
        }



        public async Task<LoginResponseDto> LoginAsync(Usuario request)
        {
            var usuario = await _context.Usuarios
                    .SingleOrDefaultAsync(u => u.UsuarioLogin == request.UsuarioLogin);

            if (usuario == null || !PasswordHasher.Verify(request.ClaveHash, usuario.ClaveHash))
                throw new Exception("Usuario o contraseña inválidos.");
            LoginRequestDto user = _mapper.Map<LoginRequestDto>(request);
            var token = _jwtTokenService.GenerateToken(user);

            return new LoginResponseDto
            {
                Token = token,
                ExpiraEn = DateTime.UtcNow.AddMinutes(60)
            };
        }
    }
}
