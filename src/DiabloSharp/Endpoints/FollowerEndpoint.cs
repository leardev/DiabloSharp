using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiabloSharp.Mappers;
using DiabloSharp.Models;
using DiabloSharp.RateLimiters;

namespace DiabloSharp.Endpoints
{
    internal class FollowerEndpoint : Endpoint,
                                      IFollowerEndpoint
    {
        public FollowerEndpoint(ITokenBucket tokenBucket) : base(tokenBucket)
        {
        }

        public async Task<Follower> GetFollowerAsync(IAuthenticationScope authenticationScope, FollowerIdentifier followerId)
        {
            var mapper = new FollowerMapper();
            var followerSlug = followerId.ToString().ToLower();

            using (var client = CreateClient(authenticationScope))
            {
                var follower = await client.GetFollowerAsync(followerSlug);
                return mapper.Map(follower);
            }
        }

        public async Task<IEnumerable<Follower>> GetFollowersAsync(IAuthenticationScope authenticationScope)
        {
            var followerIds = Enum.GetValues(typeof(FollowerIdentifier))
                .Cast<FollowerIdentifier>()
                .ToList();

            var followersTasks = followerIds.Select(id => GetFollowerAsync(authenticationScope, id));
            var followers = await Task.WhenAll(followersTasks);
            return followers;
        }
    }
}