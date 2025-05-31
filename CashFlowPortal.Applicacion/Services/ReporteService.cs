using CashFlowPortal.Applicacion.DTOs.Reporte;
using CashFlowPortal.Applicacion.Interfaces.IRepository;
using CashFlowPortal.Applicacion.Interfaces.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashFlowPortal.Applicacion.Services
{
    public class ReporteService : IReporteService
    {
        private readonly IReporteRepository _repo;
        public ReporteService(IReporteRepository repo) => _repo = repo;

        public Task<List<PresupuestoEjecucionDto>> GetComparativoAsync(DateTime desde, DateTime hasta)
            => _repo.GetComparativoAsync(desde, hasta);
    }
}
