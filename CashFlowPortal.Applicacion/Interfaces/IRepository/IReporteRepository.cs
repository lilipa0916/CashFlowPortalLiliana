using CashFlowPortal.Applicacion.DTOs.Reporte;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashFlowPortal.Applicacion.Interfaces.IRepository
{
    public interface IReporteRepository
    {
        Task<List<PresupuestoEjecucionDto>> GetComparativoAsync(DateTime desde, DateTime hasta);
    }
}
