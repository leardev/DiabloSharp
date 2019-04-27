using DiabloSharp.Clients;
using DiabloSharp.Extensions;
using DiabloSharp.Models;
using DiabloSharp.RateLimiters;

namespace DiabloSharp.Endpoints
{
    internal abstract class Endpoint : IEndpoint
    {
        private readonly ITokenBucket _tokenBucket;

        protected Endpoint(ITokenBucket tokenBucket)
        {
            _tokenBucket = tokenBucket;
        }

        internal BattleNetClient CreateClient(AuthenticationScope authenticationScope)
        {
            authenticationScope.EnsureExpiration();
            return new BattleNetClient(authenticationScope.AccessToken, authenticationScope.Region.ToDescription(),
                authenticationScope.Localization.ToDescription(), _tokenBucket);
        }
    }
}