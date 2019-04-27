using System.Threading.Tasks;
using DiabloSharp.Clients;
using DiabloSharp.Extensions;
using DiabloSharp.Models;
using DiabloSharp.RateLimiters;

namespace DiabloSharp.Endpoints
{
    internal class OAuthEndpoint : IOAuthEndpoint
    {
        private readonly ITokenBucket _tokenBucket;

        public OAuthEndpoint(ITokenBucket tokenBucket)
        {
            _tokenBucket = tokenBucket;
        }

        public async Task<OAuthToken> GetTokenAsync(string clientId, string clientSecret, Region region)
        {
            using (var client = new OAuthClient(clientId, clientSecret, region.ToDescription(), _tokenBucket))
            {
                var token = await client.GetTokenAsync();
                return new OAuthToken
                {
                    AccessToken = token.AccessToken,
                    SecondsUntilExpiration = token.SecondsUntilExpiration
                };
            }
        }
    }
}