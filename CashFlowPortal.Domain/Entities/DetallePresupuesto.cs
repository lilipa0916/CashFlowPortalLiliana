using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashFlowPortal.Domain.Entities
{
    public class DetallePresupuesto
    {
        public Guid Id { get; set; }
        public Guid PresupuestoId { get; set; }
        public Guid TipoGastoId { get; set; }
        public decimal MontoPresupuestado { get; set; }

        public TipoGasto TipoGasto { get; set; } = default!;
        public Presupuesto Presupuesto { get; set; }

    }
}
