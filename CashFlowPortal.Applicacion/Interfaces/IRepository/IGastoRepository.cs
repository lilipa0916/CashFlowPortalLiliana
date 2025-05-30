using CashFlowPortal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashFlowPortal.Applicacion.Interfaces.IRepository
{
    public interface IGastoRepository
    {
        /// <summary>
        /// Inserta encabezado + detalle en una única transacción.
        /// </summary>
        Task<int> AddWithDetalleAsync(Gasto entity);

        /// <summary>
        /// Suma los gastos de un tipo en un mes (para validación de presupuesto).
        /// </summary>
        Task<decimal> SumByTipoAndMesAsync(Guid tipoGastoId, DateTime mes);
    }
}
