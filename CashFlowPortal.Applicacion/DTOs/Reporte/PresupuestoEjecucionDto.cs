namespace CashFlowPortal.Applicacion.DTOs.Reporte
{
    public class PresupuestoEjecucionDto
    {
        public string TipoGasto { get; set; } = null!;
        public decimal Presupuestado { get; set; }
        public decimal Ejecutado { get; set; }
    }
}
