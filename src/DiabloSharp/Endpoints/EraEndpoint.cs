using System.Threading.Tasks;
using DiabloSharp.Clients;
using DiabloSharp.DataTransferObjects;

namespace DiabloSharp.Endpoints
{
    public class EraEndpoint
    {
        public async Task<EraIndexDto> GetEraIndexAsync(IAuthenticationScope authenticationScope)
        {
            using (var client = new BattleNetClient(authenticationScope))
                return await client.GetAsync<EraIndexDto>("/data/d3/era/");
        }

        public async Task<EraDto> GetEraAsync(IAuthenticationScope authenticationScope, long eraId)
        {
            using (var client = new BattleNetClient(authenticationScope))
                return await client.GetAsync<EraDto>($"/data/d3/era/{eraId}");
        }

        public async Task<EraLeaderboardDetailDto> GetEraLeaderboardAsync(IAuthenticationScope authenticationScope, long eraId, string leaderboardId)
        {
            using (var client = new BattleNetClient(authenticationScope))
                return await client.GetAsync<EraLeaderboardDetailDto>($"/data/d3/era/{eraId}/leaderboard/{leaderboardId}");
        }
    }
}