using AutoMapper;
using CashFlowPortal.Applicacion.DTOs.Auth;
using CashFlowPortal.Applicacion.Interfaces.IServices;
using CashFlowPortal.Domain.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CashFlowPortal.Applicacion.Services
{
    public class JwtTokenService : IJwtTokenService
    {

        private readonly JwtSettings _jwtSettings;
        private readonly IMapper _mapper;

        public JwtTokenService(IOptions<JwtSettings> options, IMapper mapper)
        {
            _jwtSettings = options.Value;
            _mapper = mapper;
        }

        public string GenerateToken(LoginRequestDto useLog)
        {
            Usuario user= _mapper.Map<Usuario>(useLog); ;
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UsuarioLogin),  // Podrías usar user.Nombre, pero Username suele ser más práctico
                new Claim(ClaimTypes.Role, user.Rol)            // Si quieres enviar rol en el token
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
