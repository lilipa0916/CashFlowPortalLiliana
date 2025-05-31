using AutoMapper;
using CashFlowPortal.API.Settings;
using CashFlowPortal.Applicacion.DTOs.Auth;
using CashFlowPortal.Applicacion.Interfaces.IServices;
using CashFlowPortal.Applicacion.Services;
using CashFlowPortal.Domain.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using JwtSettings = CashFlowPortal.Applicacion.Services.JwtSettings;
namespace CashFlowPortal.API.Services
{
    public class JwtTokenService: IJwtTokenService
    {
        private readonly JwtSettings _jwtSettings;
        public JwtTokenService(IOptions<JwtSettings> options, IMapper mapper)
        {
            _jwtSettings = options.Value;
        }

        public string GenerateToken(Usuario user)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UsuarioLogin),
                new Claim(ClaimTypes.Role, user.Rol)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_jwtSettings.ExpirationMinutes),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
