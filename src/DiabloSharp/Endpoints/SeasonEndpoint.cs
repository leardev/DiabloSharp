using System.Threading.Tasks;
using DiabloSharp.Clients;
using DiabloSharp.Extensions;
using DiabloSharp.Models;
using RestSharp;

namespace DiabloSharp.Endpoints
{
    public class SeasonEndpoint
    {
        public async Task<Seasons> GetSeasons(IAuthenticationScope authenticationScope)
        {
            var client = new BattleNetClient(authenticationScope);
            var request = new RestRequest("/data/d3/season/");
            var response = await client.ExecuteTaskAsync<Seasons>(request);
            response.EnsureSuccess();

            return response.Data;
        }

        public async Task<Season> GetSeason(IAuthenticationScope authenticationScope, int seasonId)
        {
            var client = new BattleNetClient(authenticationScope);
            var request = new RestRequest($"/data/d3/season/{seasonId}");
            var response = await client.ExecuteTaskAsync<Season>(request);
            response.EnsureSuccess();

            return response.Data;
        }

        public async Task<SeasonLeaderboardDetail> GetSeasonLeaderboardDetail(IAuthenticationScope authenticationScope, int seasonId, string leaderboardId)
        {
            var client = new BattleNetClient(authenticationScope);
            var request = new RestRequest($"/data/d3/season/{seasonId}/leaderboard/{leaderboardId}");
            var response = await client.ExecuteTaskAsync<SeasonLeaderboardDetail>(request);
            response.EnsureSuccess();

            return response.Data;
        }
    }
}