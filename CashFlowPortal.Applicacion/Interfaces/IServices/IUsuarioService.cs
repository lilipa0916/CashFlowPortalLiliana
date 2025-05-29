using CashFlowPortal.Applicacion.DTOs;

namespace CashFlowPortal.Applicacion.Interfaces.Services
{
    public interface IUsuarioService
    {
        Task<UsuarioDto> AutenticarAsync(LoginDto loginDto);
        // Task<UsuarioDto> CrearUsuarioAsync(CreateUsuarioDto usuarioDto);
        Task<IEnumerable<UsuarioDto>> ObtenerTodosAsync();
        Task<UsuarioDto?> ObtenerPorIdAsync(int id);
        Task<bool> EliminarAsync(int id);
    }
}
