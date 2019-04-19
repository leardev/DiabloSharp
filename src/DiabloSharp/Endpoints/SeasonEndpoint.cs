using System.Threading.Tasks;
using DiabloSharp.Clients;
using DiabloSharp.DataTransferObjects;

namespace DiabloSharp.Endpoints
{
    public class SeasonEndpoint
    {
        public async Task<SeasonIndexDto> GetSeasonIndexAsync(IAuthenticationScope authenticationScope)
        {
            using (var client = new BattleNetClient(authenticationScope))
                return await client.GetAsync<SeasonIndexDto>("/data/d3/season/");
        }

        public async Task<SeasonDto> GetSeasonAsync(IAuthenticationScope authenticationScope, long seasonId)
        {
            using (var client = new BattleNetClient(authenticationScope))
                return await client.GetAsync<SeasonDto>($"/data/d3/season/{seasonId}");
        }

        public async Task<SeasonLeaderboardDetailDto> GetSeasonLeaderboardAsync(IAuthenticationScope authenticationScope, long seasonId, string leaderboardId)
        {
            using (var client = new BattleNetClient(authenticationScope))
                return await client.GetAsync<SeasonLeaderboardDetailDto>($"/data/d3/season/{seasonId}/leaderboard/{leaderboardId}");
        }
    }
}