using System.ComponentModel.DataAnnotations;

namespace CashFlowPortal.Applicacion.DTOs.Auth
{
    public class LoginRequestDto
    {
        [Required]
        public string Usuario { get; set; } = string.Empty;
        [Required]
        public string Clave { get; set; } = string.Empty;

    }
}
