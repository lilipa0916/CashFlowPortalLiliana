using CashFlowPortal.Applicacion.DTOs;
using CashFlowPortal.Applicacion.DTOs.Auth;
using CashFlowPortal.Applicacion.DTOs.Usuario;

namespace CashFlowPortal.Applicacion.Interfaces.Services
{
    public interface IUsuarioService
    {
        Task<UsuarioDto> AutenticarAsync(LoginRequestDto loginDto);
        Task<IEnumerable<UsuarioDto>> ObtenerTodosAsync();
        Task<UsuarioDto?> ObtenerPorIdAsync(int id);
           Task<UsuarioDto?> ObtenerUsuarioPorCredencialesAsync(string usuario, string contraseña);
        Task<UsuarioDto?> GetByIdAsync(Guid id);
        Task<UsuarioDto?> GetByUsernameAsync(string username);
        Task<UsuarioDto?> AuthenticateAsync(string username, string password);

    }
}
