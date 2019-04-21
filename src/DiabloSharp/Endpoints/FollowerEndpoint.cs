using System.Threading.Tasks;
using DiabloSharp.DataTransferObjects;
using DiabloSharp.Models;
using DiabloSharp.RateLimiters;

namespace DiabloSharp.Endpoints
{
    public class FollowerEndpoint : EndpointBase
    {
        public FollowerEndpoint(ITokenBucket tokenBucket) : base(tokenBucket)
        {
        }

        public async Task<FollowerDto> GetFollowerAsync(AuthenticationScope authenticationScope, string followerSlug)
        {
            using (var client = CreateClient(authenticationScope))
                return await client.GetFollowerAsync(followerSlug);
        }
    }
}