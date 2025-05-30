using CashFlowPortal.Applicacion.Interfaces.IServices;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace CashFlowPortal.Web.Services
{
    public class CurrentUserService : ICurrentUserService
    {

        private readonly AuthenticationStateProvider _authProvider;
        public CurrentUserService(AuthenticationStateProvider authProvider)
        {
            _authProvider = authProvider;
        }

        public async Task<Guid> GetUserIdAsync()
        {
            var state = await _authProvider.GetAuthenticationStateAsync();
            var user = state.User;

            // Intentamos la claim ClaimTypes.NameIdentifier ("sub")
            var idClaim = user.FindFirst(ClaimTypes.NameIdentifier)?.Value
                       ?? user.FindFirst("sub")?.Value;

            if (idClaim == null || !Guid.TryParse(idClaim, out var guid))
                throw new InvalidOperationException("Usuario no autenticado o claim inválido.");

            return guid;
        }
    }
}
