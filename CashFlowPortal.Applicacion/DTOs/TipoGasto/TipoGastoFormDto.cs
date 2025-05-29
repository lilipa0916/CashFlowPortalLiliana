using System.ComponentModel.DataAnnotations;

namespace CashFlowPortal.Applicacion.DTOs.TipoGasto
{
    // CashFlowPortal.Applicacion/DTOs/TipoGasto/TipoGastoFormDto.cs
    public class TipoGastoFormDto
    {
        public Guid? Id { get; set; }

        [Required, MaxLength(100)]
        public string Nombre { get; set; } = string.Empty;
    }
}
