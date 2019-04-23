using System;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using DiabloSharp.DataTransferObjects;
using DiabloSharp.RateLimiters;

namespace DiabloSharp.Clients
{
    internal class OAuthClient : HttpClientBase
    {
        public OAuthClient(string clientId, string clientSecret, string region, ITokenBucket tokenBucket) : base($"https://{region}.battle.net", tokenBucket)
        {
            var credentials = Encoding.ASCII.GetBytes($"{clientId}:{clientSecret}");
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(credentials));
            AddParameter("grant_type", "client_credentials");
        }

        public async Task<OAuthTokenDto> GetTokenAsync()
        {
            return await PostAsync<OAuthTokenDto>("oauth/token");
        }
    }
}