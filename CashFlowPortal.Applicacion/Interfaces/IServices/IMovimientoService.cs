using CashFlowPortal.Applicacion.DTOs.Consulta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashFlowPortal.Applicacion.Interfaces.IServices
{
    public interface IMovimientoService
    {
        Task<List<MovimientoDto>> GetMovimientosAsync(DateTime fechaDesde, DateTime fechaHasta);
    }
}
