namespace CashFlowPortal.Domain.Entities
{
    public class Deposito
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public int FondoMonetarioId { get; set; }
        public decimal Monto { get; set; }

        public FondoMonetario FondoMonetario { get; set; } = default!;
    }
}
