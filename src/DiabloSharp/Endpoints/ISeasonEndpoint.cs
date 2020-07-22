using System.Collections.Generic;
using System.Threading.Tasks;
using DiabloSharp.Models;

namespace DiabloSharp.Endpoints
{
    public interface ISeasonEndpoint : IEndpoint
    {
        Task<IEnumerable<SeasonId>> GetSeasonIdsAsync();

        Task<SeasonId> GetActiveSeasonIdAsync();

        Task<SoloLeaderboard> GetSoloLeaderboard(IAuthenticationScope authenticationScope, SoloLeaderboardId leaderboardId);
    }
}