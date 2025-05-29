namespace CashFlowPortal.Domain.Entities
{
    public class Presupuesto
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; } 
        public int TipoGastoId { get; set; }
        /// <summary>
        /// Solo se usa año/mes
        /// </summary>
        public DateTime Mes { get; set; } 
        public decimal Monto { get; set; }

        public TipoGasto TipoGasto { get; set; } = default!;
    }
}
