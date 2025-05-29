using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashFlowPortal.Domain.Entities
{
    public class DetallePresupuesto
    {
        public int Id { get; set; }
        public int PresupuestoId { get; set; }
        public int TipoGastoId { get; set; }
        public decimal MontoPresupuestado { get; set; }

        public TipoGasto TipoGasto { get; set; } = default!;

    }
}
