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
                return await client.GetSeasonIndexAsync();
        }

        public async Task<SeasonDto> GetSeasonAsync(AuthenticationScope authenticationScope, long seasonId)
        {
            using (var client = CreateClient(authenticationScope))
                return await client.GetSeasonAsync(seasonId);
        }

        public async Task<SeasonLeaderboardDetailDto> GetSeasonLeaderboardAsync(AuthenticationScope authenticationScope, long seasonId, string leaderboardId)
        {
            using (var client = CreateClient(authenticationScope))
                return await client.GetSeasonLeaderboardAsync(seasonId, leaderboardId);
        }
    }
}