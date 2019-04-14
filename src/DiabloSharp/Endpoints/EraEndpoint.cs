using System.Threading.Tasks;
using DiabloSharp.Clients;
using DiabloSharp.Extensions;
using DiabloSharp.Models;
using RestSharp;

namespace DiabloSharp.Endpoints
{
    public class EraEndpoint
    {
        public async Task<EraIndex> GetEraIndexAsync(IAuthenticationScope authenticationScope)
        {
            var client = new BattleNetClient(authenticationScope);
            var request = new RestRequest("/data/d3/era/");
            var response = await client.ExecuteTaskAsync<EraIndex>(request);
            response.EnsureSuccess();

            return response.Data;
        }

        public async Task<Era> GetEraAsync(IAuthenticationScope authenticationScope, long eraId)
        {
            var client = new BattleNetClient(authenticationScope);
            var request = new RestRequest($"/data/d3/era/{eraId}");
            var response = await client.ExecuteTaskAsync<Era>(request);
            response.EnsureSuccess();

            return response.Data;
        }

        public async Task<EraLeaderboardDetail> GetEraLeaderboardAsync(IAuthenticationScope authenticationScope, long eraId, string leaderboardId)
        {
            var client = new BattleNetClient(authenticationScope);
            var request = new RestRequest($"/data/d3/era/{eraId}/leaderboard/{leaderboardId}");
            var response = await client.ExecuteTaskAsync<EraLeaderboardDetail>(request);
            response.EnsureSuccess();

            return response.Data;
        }
    }
}