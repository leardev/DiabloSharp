using System.Threading.Tasks;
using DiabloSharp.Clients;
using DiabloSharp.Models;

namespace DiabloSharp.Endpoints
{
    public class EraEndpoint
    {
        public async Task<EraIndex> GetEraIndexAsync(IAuthenticationScope authenticationScope)
        {
            using (var client = new BattleNetClient(authenticationScope))
                return await client.GetAsync<EraIndex>("/data/d3/era/");
        }

        public async Task<Era> GetEraAsync(IAuthenticationScope authenticationScope, long eraId)
        {
            using (var client = new BattleNetClient(authenticationScope))
                return await client.GetAsync<Era>($"/data/d3/era/{eraId}");
        }

        public async Task<EraLeaderboardDetail> GetEraLeaderboardAsync(IAuthenticationScope authenticationScope, long eraId, string leaderboardId)
        {
            using (var client = new BattleNetClient(authenticationScope))
                return await client.GetAsync<EraLeaderboardDetail>($"/data/d3/era/{eraId}/leaderboard/{leaderboardId}");
        }
    }
}