using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashFlowPortal.Applicacion.DTOs.TipoGasto
{
    public   class UpdateTipoGastoDto : CreateTipoGastoDto
    {
        public Guid Id { get; set; }
    }
}
