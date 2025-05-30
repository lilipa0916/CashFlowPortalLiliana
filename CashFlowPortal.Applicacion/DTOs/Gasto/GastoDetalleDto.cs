using System.ComponentModel.DataAnnotations;

namespace CashFlowPortal.Applicacion.DTOs.Gasto
{
    public class GastoDetalleDto
    {
        public int Id { get; set; }

        [Required]
        public Guid TipoGastoId { get; set; }

        [Required]
        [Range(0.01, double.MaxValue)]
        public decimal Monto { get; set; }
    }
}
