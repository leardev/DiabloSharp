using System.Threading.Tasks;
using DiabloSharp.Clients;
using DiabloSharp.DataTransferObjects;
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

        public async Task<OAuthTokenDto> GetTokenAsync(string clientId, string clientSecret, Region region)
        {
            using (var client = new OAuthClient(clientId, clientSecret, region.ToDescription(), _tokenBucket))
                return await client.GetTokenAsync();
        }
    }
}