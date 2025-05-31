using AutoMapper;
using CashFlowPortal.API.Settings;
using CashFlowPortal.Applicacion.DTOs.Auth;
using CashFlowPortal.Applicacion.Interfaces.IServices;
using CashFlowPortal.Domain.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CashFlowPortal.API.Services
{
    public class JwtTokenService: IJwtTokenService
    {
        private readonly JwtSettings _settings;
        private readonly IMapper _mapper;
        public JwtTokenService(IOptions<JwtSettings> options, IMapper mapper)
        {
            _settings = options.Value;
            _mapper = mapper;
        }

        public string GenerateToken(LoginRequestDto useLog )
        {
            Usuario usuario = _mapper.Map<Usuario>(useLog);
            var claims = new[]
            {
            new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
            new Claim(ClaimTypes.Name, usuario.Nombre),
          //  new Claim(ClaimTypes.Email, usuario.Correo)
        };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.SecretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                _settings.Issuer,
                _settings.Audience,
                claims,
                expires: DateTime.UtcNow.AddMinutes(_settings.ExpirationMinutes),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
