namespace CashFlowPortal.Domain.Entities
{
    public class FondoMonetario
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = default!;
        public string Tipo { get; set; } = default!; // Banco, Caja chica, etc.
        public decimal Saldo { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
