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
                var storedTokenResult = await _sessionStorage.GetAsync<string>(TokenKey);
                var token = storedTokenResult.Success ? storedTokenResult.Value : null;

                if (string.IsNullOrEmpty(token))
                {
                    var anonymous = new ClaimsPrincipal(new ClaimsIdentity());
                    return new AuthenticationState(anonymous);
                }

                var jwtHandler = new JwtSecurityTokenHandler();
                var jwtToken = jwtHandler.ReadJwtToken(token);

                var claims = new List<Claim>();
                foreach (var claim in jwtToken.Claims)
                {
                    claims.Add(claim);
                }

                var identity = new ClaimsIdentity(claims, "jwt");
                var user = new ClaimsPrincipal(identity);

                return new AuthenticationState(user);
            }
            catch
            {
                var anonymous = new ClaimsPrincipal(new ClaimsIdentity());
                return new AuthenticationState(anonymous);
            }
        }

        public async Task MarkUserAsAuthenticated(string token)
        {
            await _sessionStorage.SetAsync(TokenKey, token);

            var jwtHandler = new JwtSecurityTokenHandler();
            var jwtToken = jwtHandler.ReadJwtToken(token);
            var claims = jwtToken.Claims.Select(c => new Claim(c.Type, c.Value));
            var identity = new ClaimsIdentity(claims, "jwt");
            var user = new ClaimsPrincipal(identity);

            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
        }

        public async Task MarkUserAsLoggedOut()
        {
            await _sessionStorage.DeleteAsync(TokenKey);

            var anonymous = new ClaimsPrincipal(new ClaimsIdentity());
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(anonymous)));
        }
    }
}
