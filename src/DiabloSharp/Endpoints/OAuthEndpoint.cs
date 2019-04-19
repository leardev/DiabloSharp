using System.Threading.Tasks;
using DiabloSharp.Clients;
using DiabloSharp.DataTransferObjects;
using DiabloSharp.Extensions;
using DiabloSharp.Models;

namespace DiabloSharp.Endpoints
{
    internal class OAuthEndpoint
    {
        public async Task<OAuthTokenDto> GetTokenAsync(string clientId, string clientSecret, Region region)
        {
            using (var client = new OAuthClient(clientId, clientSecret, region.ToDescription()))
                return await client.PostAsync<OAuthTokenDto>("oauth/token");
        }
    }
}