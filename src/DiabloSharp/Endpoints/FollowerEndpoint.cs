using System.Threading.Tasks;
using DiabloSharp.Clients;
using DiabloSharp.Models;

namespace DiabloSharp.Endpoints
{
    public class FollowerEndpoint
    {
        public async Task<Follower> GetFollowerAsync(IAuthenticationScope authenticationScope, string followerSlug)
        {
            using (var client = new BattleNetClient(authenticationScope))
                return await client.GetAsync<Follower>($"/d3/data/follower/{followerSlug}");
        }
    }
}