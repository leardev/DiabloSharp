using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiabloSharp.Mappers;
using DiabloSharp.Models;
using DiabloSharp.RateLimiters;

namespace DiabloSharp.Endpoints
{
    internal class SeasonEndpoint : Endpoint,
                                    ISeasonEndpoint
    {
        public SeasonEndpoint(ITokenBucket tokenBucket)
            : base(tokenBucket)
        {
        }

        public Task<IEnumerable<SeasonId>> GetSeasonIdsAsync()
        {
            var seasonIds = Enum.GetValues(typeof(SeasonId))
                .Cast<SeasonId>();
            return Task.FromResult(seasonIds);
        }

        public Task<SeasonId> GetActiveSeasonIdAsync()
        {
            var highestSeason = Enum.GetValues(typeof(SeasonId))
                .Cast<SeasonId>()
                .Max();
            return Task.FromResult(highestSeason);
        }

        public async Task<SoloLeaderboard> GetSoloLeaderboard(IAuthenticationScope authenticationScope, SoloLeaderboardId leaderboardId)
        {
            var mapper = new SoloLeaderboardMapper(leaderboardId);
            var leaderboardSlug = leaderboardId.ToSlug();
            var seasonIndex = (int)leaderboardId.SeasonId;

            using (var client = CreateClient(authenticationScope))
            {
                var seasonLeaderboardDetail = await client.GetSeasonLeaderboardAsync(seasonIndex, leaderboardSlug);
                return mapper.Map(seasonLeaderboardDetail);
            }
        }
    }
}