using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashFlowPortal.Applicacion.Interfaces.IServices
{
    /// <summary>
    /// Servicio para obtener información del usuario actualmente autenticado.
    /// </summary>
    public interface ICurrentUserService
    {
        /// <summary>
        /// Obtiene el Id (GUID) del usuario actual según su Claim 'sub' o NameIdentifier.
        /// </summary>
        Task<Guid> GetUserIdAsync();
    }
}
