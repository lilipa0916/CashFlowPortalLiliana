namespace CashFlowPortal.Domain.Entities
{
    public class TipoGasto
    {
        public Guid Id { get; set; }
        public string Codigo { get; set; } = default!;
        public string Nombre { get; set; } = default!;
    }
}
