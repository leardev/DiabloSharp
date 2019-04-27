using System.Threading.Tasks;
using DiabloSharp.Models;

namespace DiabloSharp.Endpoints
{
    internal interface IOAuthEndpoint : IEndpoint
    {
        Task<OAuthToken> GetTokenAsync(string clientId, string clientSecret, Region region);
    }
}