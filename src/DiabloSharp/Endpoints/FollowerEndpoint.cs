using System.Threading.Tasks;
using DiabloSharp.Clients;
using DiabloSharp.DataTransferObjects;
using DiabloSharp.Extensions;
using RestSharp;

namespace DiabloSharp.Endpoints
{
    public class FollowerEndpoint
    {
        public async Task<FollowerDto> GetFollowerAsync(IAuthenticationScope authenticationScope, string followerSlug)
        {
            var client = new BattleNetClient(authenticationScope);
            var request = new RestRequest($"/d3/data/follower/{followerSlug}");
            var response = await client.ExecuteTaskAsync<FollowerDto>(request);
            response.EnsureSuccess();

            return response.Data;
        }
    }
}