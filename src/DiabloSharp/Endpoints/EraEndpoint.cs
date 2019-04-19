using System.Threading.Tasks;
using DiabloSharp.Clients;
using DiabloSharp.DataTransferObjects;
using DiabloSharp.Extensions;
using RestSharp;

namespace DiabloSharp.Endpoints
{
    public class EraEndpoint
    {
        public async Task<EraIndexDto> GetEraIndexAsync(IAuthenticationScope authenticationScope)
        {
            var client = new BattleNetClient(authenticationScope);
            var request = new RestRequest("/data/d3/era/");
            var response = await client.ExecuteTaskAsync<EraIndexDto>(request);
            response.EnsureSuccess();

            return response.Data;
        }

        public async Task<EraDto> GetEraAsync(IAuthenticationScope authenticationScope, long eraId)
        {
            var client = new BattleNetClient(authenticationScope);
            var request = new RestRequest($"/data/d3/era/{eraId}");
            var response = await client.ExecuteTaskAsync<EraDto>(request);
            response.EnsureSuccess();

            return response.Data;
        }

        public async Task<EraLeaderboardDetailDto> GetEraLeaderboardAsync(IAuthenticationScope authenticationScope, long eraId, string leaderboardId)
        {
            var client = new BattleNetClient(authenticationScope);
            var request = new RestRequest($"/data/d3/era/{eraId}/leaderboard/{leaderboardId}");
            var response = await client.ExecuteTaskAsync<EraLeaderboardDetailDto>(request);
            response.EnsureSuccess();

            return response.Data;
        }
    }
}