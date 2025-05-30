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
        public Guid Id { get; set; }
        public Guid UsuarioId { get; set; }
        public Guid TipoGastoId { get; set; }
        public DateTime Mes { get; set; }
        public decimal Monto { get; set; }
        public List<PresupuestoDetalleDto> Detalles { get; set; } = new();
    }
}
