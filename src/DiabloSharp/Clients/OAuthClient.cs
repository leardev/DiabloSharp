using System;
using System.Net.Http.Headers;
using System.Text;

namespace DiabloSharp.Clients
{
    internal class OAuthClient : HttpClientBase
    {
        public OAuthClient(string clientId, string clientSecret, string region) : base($"https://{region}.battle.net")
        {
            var credentials = Encoding.ASCII.GetBytes($"{clientId}:{clientSecret}");
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(credentials));
            AddParameter("grant_type", "client_credentials");
        }
    }
}