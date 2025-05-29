using System.ComponentModel.DataAnnotations;

namespace CashFlowPortal.Applicacion.DTOs
{
    public class UsuarioDto
    {
        public Guid Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string UsuarioLogin { get; set; } = string.Empty;

        [Required]
        [MinLength(4)]
        public string Password { get; set; } = string.Empty;
    }
}
