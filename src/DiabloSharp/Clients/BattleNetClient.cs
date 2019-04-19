using System.Threading.Tasks;
using DiabloSharp.Extensions;

namespace DiabloSharp.Clients
{
    internal class BattleNetClient : HttpClientBase
    {
        private readonly IAuthenticationScope _authenticationScope;

        public BattleNetClient(IAuthenticationScope authenticationScope) : base($"https://{authenticationScope.Region.ToDescription()}.api.blizzard.com")
        {
            _authenticationScope = authenticationScope;
            AddParameter("access_token", _authenticationScope.AccessToken);
            AddParameter("locale", _authenticationScope.Localization.ToDescription());
        }

        public override async Task<T> GetAsync<T>(string requestUri)
        {
            _authenticationScope.EnsureExpiration();
            return await base.GetAsync<T>(requestUri);
        }
    }
}