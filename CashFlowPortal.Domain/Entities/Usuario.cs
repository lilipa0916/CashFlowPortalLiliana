namespace CashFlowPortal.Domain.Entities
{
    public class Usuario
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Nombre { get; set; } = string.Empty;
        public string UsuarioLogin { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        
        public string ClaveHash { get; set; } = null!;

        public string Rol { get; set; } = null!;
    }
}
