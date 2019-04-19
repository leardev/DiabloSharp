using System.Threading.Tasks;
using DiabloSharp.Clients;
using DiabloSharp.Models;

namespace DiabloSharp.Endpoints
{
    public class SeasonEndpoint
    {
        public async Task<SeasonIndex> GetSeasonIndexAsync(IAuthenticationScope authenticationScope)
        {
            using (var client = new BattleNetClient(authenticationScope))
                return await client.GetAsync<SeasonIndex>("/data/d3/season/");
        }

        public async Task<Season> GetSeasonAsync(IAuthenticationScope authenticationScope, long seasonId)
        {
            using (var client = new BattleNetClient(authenticationScope))
                return await client.GetAsync<Season>($"/data/d3/season/{seasonId}");
        }

        public async Task<SeasonLeaderboardDetail> GetSeasonLeaderboardAsync(IAuthenticationScope authenticationScope, long seasonId, string leaderboardId)
        {
            using (var client = new BattleNetClient(authenticationScope))
                return await client.GetAsync<SeasonLeaderboardDetail>($"/data/d3/season/{seasonId}/leaderboard/{leaderboardId}");
        }
    }
}