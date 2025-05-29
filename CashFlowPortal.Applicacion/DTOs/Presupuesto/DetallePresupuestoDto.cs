using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashFlowPortal.Applicacion.DTOs.Presupuesto
{
    public class DetallePresupuestoDto
    {
        public int Id { get; set; }
        public DateTime Mes { get; set; }

        public List<DetallePresupuestoDto> Detalles { get; set; }
    }
}
