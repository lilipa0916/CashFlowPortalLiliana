namespace CashFlowPortal.Domain.Entities
{
    public class Gasto
    {
        public int Id { get; set; }
        public Guid UsuarioId { get; set; }

        public DateTime Fecha { get; set; }
        public int FondoMonetarioId { get; set; }
        public string Observaciones { get; set; } = default!;
        public string Comercio { get; set; } = default!;
        public string TipoDocumento { get; set; } = default!;

        public Usuario Usuario { get; set; }

        public FondoMonetario FondoMonetario { get; set; } = default!;
        public List<GastoDetalle> Detalles { get; set; } = new();
    }
}
