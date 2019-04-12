using System.Threading.Tasks;
using DiabloSharp.Clients;
using DiabloSharp.Extensions;
using DiabloSharp.Models;
using RestSharp;

namespace DiabloSharp.Endpoints
{
    public class FollowerEndpoint
    {
        public async Task<Follower> GetFollowerAsync(IAuthenticationScope authenticationScope, string followerSlug)
        {
            var client = new BattleNetClient(authenticationScope);
            var request = new RestRequest($"/d3/data/follower/{followerSlug}");
            var response = await client.ExecuteTaskAsync<Follower>(request);
            response.EnsureSuccess();

            return response.Data;
        }
    }
}