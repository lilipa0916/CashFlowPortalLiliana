using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashFlowPortal.Applicacion.DTOs.Deposito
{
    public class DepositoDto
    {
        public int Id { get; set; }               // opcional, puede omitirse en creación
        public DateTime Fecha { get; set; }
        public int FondoMonetarioId { get; set; }
        public decimal Monto { get; set; }
        public string FondoNombre { get; set; } = default!; // para listar en UI
    }
}
