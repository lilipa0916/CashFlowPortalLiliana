using CashFlowPortal.Applicacion.DTOs.Consulta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashFlowPortal.Applicacion.Interfaces.IRepository
{
    public interface IMovimientoRepository
    {
        Task<List<MovimientoDto>> GetMovimientosAsync(DateTime desde, DateTime hasta);
    }
}
