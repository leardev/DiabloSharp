using DiabloSharp.Extensions;
using DiabloSharp.Models;
using RestSharp;
using RestSharp.Authenticators;

namespace DiabloSharp.Clients
{
    internal class OAuthClient : RestClient
    {
        public OAuthClient(string clientId, string clientSecret, Region region) : base($"https://{region.ToDescription()}.battle.net")
        {
            Authenticator = new HttpBasicAuthenticator(clientId, clientSecret);
            AddHandler("application/json", () => new NewtonsoftJsonDeserializer());
        }
    }
}