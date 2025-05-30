namespace CashFlowPortal.Domain.Entities
{
    public class GastoDetalle
    {
        public int Id { get; set; }
        public int GastoId { get; set; }
        public Guid TipoGastoId { get; set; }
        public decimal Monto { get; set; }

        public Gasto Gasto { get; set; } = default!;
        public TipoGasto TipoGasto { get; set; } = default!;
    }
}
