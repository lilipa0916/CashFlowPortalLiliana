using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashFlowPortal.Applicacion.DTOs.Presupuesto
{
    public class PresupuestoDetalleDto
    {
        public Guid Id { get; set; }
        public Guid TipoGastoId { get; set; }
        public decimal MontoPresupuestado { get; set; }
    }
}
