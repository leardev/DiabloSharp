using DiabloSharp.Clients;
using DiabloSharp.Extensions;
using DiabloSharp.Models;
using DiabloSharp.RateLimiters;

namespace DiabloSharp.Endpoints
{
    public abstract class EndpointBase
    {
        private readonly ITokenBucket _tokenBucket;

        protected EndpointBase(ITokenBucket tokenBucket)
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