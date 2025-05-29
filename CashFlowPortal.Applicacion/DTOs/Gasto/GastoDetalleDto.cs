using System.ComponentModel.DataAnnotations;

namespace CashFlowPortal.Applicacion.DTOs.Gasto
{
    public class GastoDetalleDto
    {
        [Required]
        public int TipoGastoId { get; set; }

        [Required]
        [Range(0.01, double.MaxValue)]
        public decimal Monto { get; set; }
    }
}
