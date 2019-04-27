using System.Threading.Tasks;
using DiabloSharp.DataTransferObjects;
using DiabloSharp.Models;

namespace DiabloSharp.Endpoints
{
    internal interface IOAuthEndpoint : IEndpoint
    {
        Task<OAuthTokenDto> GetTokenAsync(string clientId, string clientSecret, Region region);
    }
}