using AutoMapper;
using CashFlowPortal.Applicacion.DTOs.Auth;
using CashFlowPortal.Applicacion.Interfaces.IRepository;
using CashFlowPortal.Applicacion.Interfaces.IServices;
using CashFlowPortal.Domain.Entities;
using CashFlowPortal.Infraestructura.Data;
using CashFlowPortal.Infraestructura.Seguridad;
using Microsoft.EntityFrameworkCore;

namespace CashFlowPortal.Infraestructura.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly AppDbContext _context;

        public AuthRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Usuario?> LoginAsync(LoginRequestDto request)
        {
            var usuario = await _context.Usuarios
                .SingleOrDefaultAsync(u => u.UsuarioLogin == request.Usuario);

            if (usuario == null)
                return null;

            if (!PasswordHasher.Verify(request.Clave, usuario.ClaveHash))
                return null;

            return usuario;
        }
    }
}
