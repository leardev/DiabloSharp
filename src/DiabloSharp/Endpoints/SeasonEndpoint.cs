using System.Threading.Tasks;
using DiabloSharp.Clients;
using DiabloSharp.DataTransferObjects;
using DiabloSharp.Extensions;
using RestSharp;

namespace DiabloSharp.Endpoints
{
    public class SeasonEndpoint
    {
        public async Task<SeasonIndexDto> GetSeasonIndexAsync(IAuthenticationScope authenticationScope)
        {
            var client = new BattleNetClient(authenticationScope);
            var request = new RestRequest("/data/d3/season/");
            var response = await client.ExecuteTaskAsync<SeasonIndexDto>(request);
            response.EnsureSuccess();

            return response.Data;
        }

        public async Task<SeasonDto> GetSeasonAsync(IAuthenticationScope authenticationScope, long seasonId)
        {
            var client = new BattleNetClient(authenticationScope);
            var request = new RestRequest($"/data/d3/season/{seasonId}");
            var response = await client.ExecuteTaskAsync<SeasonDto>(request);
            response.EnsureSuccess();

            return response.Data;
        }

        public async Task<SeasonLeaderboardDetailDto> GetSeasonLeaderboardAsync(IAuthenticationScope authenticationScope, long seasonId, string leaderboardId)
        {
            var client = new BattleNetClient(authenticationScope);
            var request = new RestRequest($"/data/d3/season/{seasonId}/leaderboard/{leaderboardId}");
            var response = await client.ExecuteTaskAsync<SeasonLeaderboardDetailDto>(request);
            response.EnsureSuccess();

            return response.Data;
        }
    }
}