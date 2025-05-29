using AutoMapper;
using CashFlowPortal.Applicacion.DTOs.Usuario;
using CashFlowPortal.Applicacion.Interfaces.IRepository;
using CashFlowPortal.Applicacion.Interfaces.Services;
using CashFlowPortal.Infraestructura.Auth;
using CashFlowPortal.Infraestructura.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CashFlowPortal.Infraestructura.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly JwtSettings _jwtSettings;

        public UsuarioService(IUsuarioRepository usuarioRepository, IOptions<JwtSettings> jwtOptions)
        {
            _usuarioRepository = usuarioRepository;
            _jwtSettings = jwtOptions.Value;
        }

        public async Task<string?> LoginAsync(string usuario, string clave)
        {
            var user = await _usuarioRepository.GetByUsuarioAsync(usuario);

            if (user == null || !BCrypt.Net.BCrypt.Verify(clave, user.ClaveHash))
                return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_jwtSettings.SecretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.Nombre),
                    new Claim(ClaimTypes.Role, "Admin") // Ajusta si deseas roles reales
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                Issuer = _jwtSettings.Issuer,
                Audience = _jwtSettings.Audience,
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature
                )
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
