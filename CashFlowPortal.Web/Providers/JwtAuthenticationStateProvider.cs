using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace CashFlowPortal.Web.Providers
{
    public class JwtAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly ProtectedSessionStorage _sessionStorage;
        private const string TokenKey = "authToken";

        public JwtAuthenticationStateProvider(ProtectedSessionStorage sessionStorage)
        {
            _sessionStorage = sessionStorage;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            try
            {
                // Intentamos leer el token desde ProtectedSessionStorage
                var storedTokenResult = await _sessionStorage.GetAsync<string>(TokenKey);
                var token = storedTokenResult.Success ? storedTokenResult.Value : null;

                if (string.IsNullOrEmpty(token))
                {
                    // No hay token: usuario no autenticado
                    var anonymous = new ClaimsPrincipal(new ClaimsIdentity());
                    return new AuthenticationState(anonymous);
                }

                // Si hay token, parseamos para extraer claims
                var jwtHandler = new JwtSecurityTokenHandler();
                var jwtToken = jwtHandler.ReadJwtToken(token);

                // Extraemos claims y creamos un ClaimsIdentity
                var claims = new List<Claim>();
                foreach (var claim in jwtToken.Claims)
                {
                    // Puedes filtrar o mapear claims si lo necesitas
                    claims.Add(claim);
                }

                var identity = new ClaimsIdentity(claims, "jwt");
                var user = new ClaimsPrincipal(identity);

                // Retornamos un AuthenticationState “autenticado”
                return new AuthenticationState(user);
            }
            catch
            {
                // Si ocurre cualquier error (token inválido, expirado, etc.), devolvemos anonymous
                var anonymous = new ClaimsPrincipal(new ClaimsIdentity());
                return new AuthenticationState(anonymous);
            }
        }

        public async Task MarkUserAsAuthenticated(string token)
        {
            // Guardar el token en sesión
            await _sessionStorage.SetAsync(TokenKey, token);

            // Creamos ClaimsPrincipal basado en ese token
            var jwtHandler = new JwtSecurityTokenHandler();
            var jwtToken = jwtHandler.ReadJwtToken(token);
            var claims = jwtToken.Claims.Select(c => new Claim(c.Type, c.Value));
            var identity = new ClaimsIdentity(claims, "jwt");
            var user = new ClaimsPrincipal(identity);

            // Notificamos a Blazor que el usuario ahora está autenticado
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
        }

        public async Task MarkUserAsLoggedOut()
        {
            // Eliminamos el token
            await _sessionStorage.DeleteAsync(TokenKey);

            // Creamos un ClaimsPrincipal vacío (no autenticado)
            var anonymous = new ClaimsPrincipal(new ClaimsIdentity());
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(anonymous)));
        }
    }
}
