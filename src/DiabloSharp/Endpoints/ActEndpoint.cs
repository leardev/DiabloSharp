using System.Threading.Tasks;
using DiabloSharp.DataTransferObjects;
using DiabloSharp.Models;
using DiabloSharp.RateLimiters;

namespace DiabloSharp.Endpoints
{
    public class ActEndpoint : EndpointBase
    {
        public ActEndpoint(ITokenBucket tokenBucket) : base(tokenBucket)
        {
        }

        public async Task<ActIndexDto> GetActIndexAsync(AuthenticationScope authenticationScope)
        {
            using (var client = CreateClient(authenticationScope))
                return await client.GetActIndexAsync();
        }

        public async Task<ActDto> GetActAsync(AuthenticationScope authenticationScope, long actId)
        {
            using (var client = CreateClient(authenticationScope))
                return await client.GetActAsync(actId);
        }
    }
}