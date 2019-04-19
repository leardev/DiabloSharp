using System.Threading.Tasks;
using DiabloSharp.Clients;
using DiabloSharp.DataTransferObjects;

namespace DiabloSharp.Endpoints
{
    public class FollowerEndpoint
    {
        public async Task<FollowerDto> GetFollowerAsync(IAuthenticationScope authenticationScope, string followerSlug)
        {
            using (var client = new BattleNetClient(authenticationScope))
                return await client.GetAsync<FollowerDto>($"/d3/data/follower/{followerSlug}");
        }
    }
}