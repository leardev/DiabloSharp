using DiabloSharp.Clients;
using DiabloSharp.Extensions;
using DiabloSharp.Helpers;
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

        internal BattleNetClient CreateClient(IAuthenticationScope authenticationScope)
        {
            authenticationScope.EnsureExpiration();
            var regionString = EnumConversionHelper.RegionToString(authenticationScope.Region);
            var localizationString = EnumConversionHelper.LocalizationToString(authenticationScope.Localization);

            return new BattleNetClient(authenticationScope.AccessToken, regionString, localizationString, _tokenBucket);
        }
    }
}