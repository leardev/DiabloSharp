using System.Threading.Tasks;
using DiabloSharp.Converters;
using DiabloSharp.Models;
using DiabloSharp.RateLimiters;

namespace DiabloSharp.Endpoints
{
    public class FollowerEndpoint : EndpointBase
    {
        private readonly FollowerConverter _followerConverter;

        public FollowerEndpoint(ITokenBucket tokenBucket) : base(tokenBucket)
        {
            _followerConverter = new FollowerConverter();
        }

        public async Task<Follower> GetFollowerAsync(AuthenticationScope authenticationScope, FollowerIdentifier followerId)
        {
            var followerSlug = followerId.ToString().ToLower();

            using (var client = CreateClient(authenticationScope))
            {
                var follower = await client.GetFollowerAsync(followerSlug);
                return _followerConverter.FollowerToModel(follower);
            }
        }
    }
}