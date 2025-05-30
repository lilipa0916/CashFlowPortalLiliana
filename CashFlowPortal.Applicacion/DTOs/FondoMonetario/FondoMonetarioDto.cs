using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashFlowPortal.Applicacion.DTOs.FondoMonetario
{
    public class FondoMonetarioDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = default!;
        public string Tipo { get; set; } = default!;
        public decimal Saldo { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
