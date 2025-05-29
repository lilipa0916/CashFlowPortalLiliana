namespace CashFlowPortal.Domain.Entities
{
    public class Presupuesto
    {
        public Guid Id { get; set; }
        public Guid UsuarioId { get; set; }
        public int TipoGastoId { get; set; }
        /// <summary>
        /// Solo se usa año/mes
        /// </summary>
        public DateTime Mes { get; set; } 
        public decimal Monto { get; set; }
        
        public Usuario Usuario { get; set; }
        public List<DetallePresupuesto> Detalles { get; set; } = new();
        public TipoGasto TipoGasto { get; set; } = null!;
    }
}
