using AutoMapper;
using CashFlowPortal.Applicacion.DTOs.Auth;
using CashFlowPortal.Applicacion.Interfaces.IRepository;
using CashFlowPortal.Applicacion.Interfaces.IServices;

namespace CashFlowPortal.Applicacion.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _repo;
        private readonly IJwtTokenService _jwtTokenService;
        private readonly IMapper _mapper;

        public AuthService(IAuthRepository repo, IJwtTokenService jwtTokenService, IMapper mapper)
        {
            _repo = repo;
            _jwtTokenService = jwtTokenService;
            _mapper = mapper;
        }

        public async Task<LoginResponseDto> LoginAsync(LoginRequestDto request)
        {
            var usuario = await _repo.LoginAsync(request);
            if (usuario == null)
                throw new Exception("Usuario o contraseña inválidos.");

            var token = _jwtTokenService.GenerateToken(usuario);

            return new LoginResponseDto
            {
                Token = token,
                Nombre = usuario.Nombre,
                Usuario = usuario.UsuarioLogin,
                Rol = usuario.Rol,
                ExpiraEn = DateTime.UtcNow.AddMinutes(60)
            };
        }
    }
}
