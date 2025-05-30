using System.ComponentModel.DataAnnotations;

namespace CashFlowPortal.Applicacion.DTOs.Gasto
{
    public class GastoDto
    {
        public int Id { get; set; }

        [Required]
        public DateTime Fecha { get; set; }

        [Required]
        public int FondoMonetarioId { get; set; }

        public string Observaciones { get; set; } = string.Empty;
        public string Comercio { get; set; } = string.Empty;
        public string TipoDocumento { get; set; } = string.Empty;

        public List<GastoDetalleDto> Detalles { get; set; } = new();
    }
}
