using System.ComponentModel.DataAnnotations;

namespace CashFlowPortal.Applicacion.DTOs
{
    public class PresupuestoDto
    {
        public int TipoGastoId { get; set; }

        [Required]
        [Range(0.01, double.MaxValue)]
        public decimal Monto { get; set; }

        [Required]
        public DateTime Mes { get; set; }
    }
}
