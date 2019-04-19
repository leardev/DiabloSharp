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
                return await client.GetEraIndexAsync();
        }

        public async Task<EraDto> GetEraAsync(AuthenticationScope authenticationScope, long eraId)
        {
            using (var client = CreateClient(authenticationScope))
                return await client.GetEraAsync(eraId);
        }

        public async Task<EraLeaderboardDetailDto> GetEraLeaderboardAsync(AuthenticationScope authenticationScope, long eraId, string leaderboardId)
        {
            using (var client = CreateClient(authenticationScope))
                return await client.GetEraLeaderboardAsync(eraId, leaderboardId);
        }
    }
}