using DiabloSharp.Extensions;
using DiabloSharp.Models;
using System;
using System.Net.Http.Headers;
using System.Text;

namespace DiabloSharp.Clients
{
    internal class OAuthClient : HttpClientBase
    {
        public OAuthClient(string clientId, string clientSecret, Region region) : base($"https://{region.ToDescription()}.battle.net")
        {
            var credentials = Encoding.ASCII.GetBytes($"{clientId}:{clientSecret}");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(credentials));
            AddParameter("grant_type", "client_credentials");
        }
    }
}