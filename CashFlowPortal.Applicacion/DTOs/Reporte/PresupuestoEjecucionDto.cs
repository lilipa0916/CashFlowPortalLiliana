using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashFlowPortal.Applicacion.DTOs.Reporte
{
    public class PresupuestoEjecucionDto
    {
        public string TipoGasto { get; set; } = null!;
        public decimal Presupuestado { get; set; }
        public decimal Ejecutado { get; set; }
    }
}
