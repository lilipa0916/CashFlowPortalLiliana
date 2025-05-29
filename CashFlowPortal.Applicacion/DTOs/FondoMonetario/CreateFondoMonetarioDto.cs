using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashFlowPortal.Applicacion.DTOs.FondoMonetario
{
    public class CreateFondoMonetarioDto
    {
        [Required, MaxLength(100)]
        public string Nombre { get; set; } = null!;

        [MaxLength(200)]
        public string Descripcion { get; set; } = null!;
    }
}
