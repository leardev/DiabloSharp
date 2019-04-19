using System.Threading.Tasks;
using DiabloSharp.DataTransferObjects;
using DiabloSharp.Models;

namespace DiabloSharp.Endpoints
{
    public class SeasonEndpoint : EndpointBase
    {
        public async Task<SeasonIndexDto> GetSeasonIndexAsync(AuthenticationScope authenticationScope)
        {
            using (var client = CreateClient(authenticationScope))
                return await client.GetAsync<SeasonIndexDto>("/data/d3/season/");
        }

        public async Task<SeasonDto> GetSeasonAsync(AuthenticationScope authenticationScope, long seasonId)
        {
            using (var client = CreateClient(authenticationScope))
                return await client.GetAsync<SeasonDto>($"/data/d3/season/{seasonId}");
        }

        public async Task<SeasonLeaderboardDetailDto> GetSeasonLeaderboardAsync(AuthenticationScope authenticationScope, long seasonId, string leaderboardId)
        {
            using (var client = CreateClient(authenticationScope))
                return await client.GetAsync<SeasonLeaderboardDetailDto>($"/data/d3/season/{seasonId}/leaderboard/{leaderboardId}");
        }
    }
}