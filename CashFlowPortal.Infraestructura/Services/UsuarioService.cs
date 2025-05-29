using AutoMapper;
using BCrypt.Net;
using CashFlowPortal.Applicacion.DTOs;
using CashFlowPortal.Applicacion.Interfaces;
using CashFlowPortal.Domain.Entities;
using CashFlowPortal.Infraestructura.Data;
using CashFlowPortal.Infraestructura.Persistencia;
using Microsoft.EntityFrameworkCore;

namespace CashFlowPortal.Infraestructura.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;
        public UsuarioService(IUsuarioRepository usuarioRepository, IMapper mapper, ApplicationDbContext context)
        {
            _usuarioRepository = usuarioRepository;
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UsuarioDto>> GetAllAsync()
        {
            var usuarios = await _usuarioRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<UsuarioDto>>(usuarios);
        }

        public async Task<UsuarioDto?> GetByIdAsync(Guid id)
        {
            var usuario = await _usuarioRepository.GetByIdAsync(id);
            return usuario == null ? null : _mapper.Map<UsuarioDto>(usuario);
        }

        //public async Task<UsuarioDto> CreateAsync(UsuarioCreateDto dto)
        //{
        //    var usuario = _mapper.Map<Usuario>(dto);
        //    usuario.Id = Guid.NewGuid();
        //    usuario.CreadoEn = DateTime.UtcNow;

        //    await _usuarioRepository.AddAsync(usuario);
        //    return _mapper.Map<UsuarioDto>(usuario);
        //}

        //public async Task<bool> UpdateAsync(Guid id, UsuarioUpdateDto dto)
        //{
        //    var usuario = await _usuarioRepository.GetByIdAsync(id);
        //    if (usuario == null) return false;

        //    _mapper.Map(dto, usuario);
        //    usuario.ModificadoEn = DateTime.UtcNow;

        //    await _usuarioRepository.UpdateAsync(usuario);
        //    return true;
        //}

        public async Task<bool> DeleteAsync(Guid id)
        {
            var usuario = await _usuarioRepository.GetByIdAsync(id);
            if (usuario == null) return false;

            await _usuarioRepository.DeleteAsync(usuario);
            return true;
        }

        public async Task<UsuarioDto?> AuthenticateAsync(string username, string password)
        {
            var usuario = await _usuarioRepository.GetByUsernameAsync(username);
            if (usuario == null || !BCrypt.Net.BCrypt.Verify(password, usuario.PasswordHash))
                return null;

            return _mapper.Map<UsuarioDto>(usuario);
        }

        Task IUsuarioService.CrearUsuarioAsync(UsuarioDto dto)
        {
            throw new NotImplementedException();
        }

        Task<UsuarioDto?> IUsuarioService.ObtenerUsuarioPorCredencialesAsync(string usuario, string contraseña)
        {
            throw new NotImplementedException();
        }

        Task<List<UsuarioDto>> IUsuarioService.ObtenerTodosAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<UsuarioDto?> AutenticarAsync(LoginDto loginDto)
        {
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Username == loginDto.Username);
            if (usuario == null) return null;

            bool passwordValida = BCrypt.Net.BCrypt.Verify(loginDto.Password, usuario.PasswordHash);
            return passwordValida ? _mapper.Map<UsuarioDto>(usuario) : null;
        }


        public async Task<IEnumerable<UsuarioDto>> ObtenerUsuariosAsync()
        {
            var usuarios = await _context.Usuarios.ToListAsync();
            return _mapper.Map<IEnumerable<UsuarioDto>>(usuarios);
        }
    }
}
