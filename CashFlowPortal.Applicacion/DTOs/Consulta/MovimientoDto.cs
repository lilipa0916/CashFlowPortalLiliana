namespace CashFlowPortal.Applicacion.DTOs.Consulta
{
    public class MovimientoDto
    {
        public DateTime Fecha { get; set; }
        public string Tipo { get; set; } = null!;    // "Gasto" o "Depósito"
        public string Fondo { get; set; } = null!;
        public string? Comercio { get; set; }        // solo para gastos
        public decimal Monto { get; set; }
    }
}
