using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashFlowPortal.Applicacion.DTOs.Presupuesto
{
    public class PresupuestoDto
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public int TipoGastoId { get; set; }
        [Required]
        [Range(0.01, double.MaxValue)]
        public decimal Monto { get; set; }

        [Required]
        public int Mes { get; set; }
        [Required]

        public int Anio { get; set; }
    }
}
