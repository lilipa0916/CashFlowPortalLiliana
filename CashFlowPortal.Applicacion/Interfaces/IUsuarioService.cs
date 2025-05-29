using CashFlowPortal.Applicacion.DTOs;

namespace CashFlowPortal.Applicacion.Interfaces
{
    public interface IUsuarioService
    {
        Task CrearUsuarioAsync(UsuarioDto dto);
        Task<UsuarioDto?> ObtenerUsuarioPorCredencialesAsync(string usuario, string contraseña);
        Task<List<UsuarioDto>> ObtenerTodosAsync();

        Task<IEnumerable<UsuarioDto>> GetAllAsync();
        Task<UsuarioDto?> GetByIdAsync(Guid id);
        Task<UsuarioDto?> GetByUsernameAsync(string username);
        //Task<bool> CreateAsync(CreateUsuarioDto dto);
        //Task<bool> UpdateAsync(UpdateUsuarioDto dto);
        Task<bool> DeleteAsync(Guid id);
        Task<UsuarioDto?> AuthenticateAsync(string username, string password);
    }
}
