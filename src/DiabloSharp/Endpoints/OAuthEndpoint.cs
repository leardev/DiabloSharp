using DiabloSharp.Clients;
using DiabloSharp.Extensions;
using DiabloSharp.Models;
using RestSharp;

namespace DiabloSharp.Endpoints
{
    internal class OAuthEndpoint
    {
        public OAuthToken GetToken(string clientId, string clientSecret, Region region)
        {
            var client = new OAuthClient(clientId, clientSecret, region);
            var request = new RestRequest("oauth/token", Method.POST);
            request.AddParameter("grant_type", "client_credentials");

            var response = client.Execute<OAuthToken>(request);
            response.EnsureSuccess();
            return response.Data;
        }
    }
}