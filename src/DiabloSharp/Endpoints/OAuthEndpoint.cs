using DiabloSharp.Clients;
using DiabloSharp.Models;
using System.Threading.Tasks;

namespace DiabloSharp.Endpoints
{
    internal class OAuthEndpoint
    {
        public async Task<OAuthToken> GetTokenAsync(string clientId, string clientSecret, Region region)
        {
            using (var client = new OAuthClient(clientId, clientSecret, region))
                return await client.PostAsync<OAuthToken>("oauth/token");
        }
    }
}