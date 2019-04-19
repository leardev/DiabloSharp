using System.Threading.Tasks;
using DiabloSharp.DataTransferObjects;
using DiabloSharp.Models;

namespace DiabloSharp.Endpoints
{
    public class EraEndpoint : EndpointBase
    {
        public async Task<EraIndexDto> GetEraIndexAsync(AuthenticationScope authenticationScope)
        {
            using (var client = CreateClient(authenticationScope))
                return await client.GetAsync<EraIndexDto>("/data/d3/era/");
        }

        public async Task<EraDto> GetEraAsync(AuthenticationScope authenticationScope, long eraId)
        {
            using (var client = CreateClient(authenticationScope))
                return await client.GetAsync<EraDto>($"/data/d3/era/{eraId}");
        }

        public async Task<EraLeaderboardDetailDto> GetEraLeaderboardAsync(AuthenticationScope authenticationScope, long eraId, string leaderboardId)
        {
            using (var client = CreateClient(authenticationScope))
                return await client.GetAsync<EraLeaderboardDetailDto>($"/data/d3/era/{eraId}/leaderboard/{leaderboardId}");
        }
    }
}