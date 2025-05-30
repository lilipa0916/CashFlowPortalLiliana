using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashFlowPortal.Applicacion.DTOs.Presupuesto
{
    public class CreatePresupuestoDto
    {
        public int UsuarioId { get; set; }
        public DateTime Mes { get; set; }
        public List<PresupuestoDetalleDto> Detalles { get; set; } = new();
    }
}
