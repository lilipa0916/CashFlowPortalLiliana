namespace CashFlowPortal.Domain.Entities
{
    public class Usuario
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string UsuarioLogin { get; set; } = null!;
        public string ClaveHash { get; set; } = null!;
        public string Rol { get; set; } = "Usuario";
    }
}
