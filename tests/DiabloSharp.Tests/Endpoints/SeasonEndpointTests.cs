using System;
using System.Linq;
using System.Threading.Tasks;
using DiabloSharp.Models;
using NUnit.Framework;

namespace DiabloSharp.Tests.Endpoints
{
    [TestFixture]
    public class SeasonEndpointTests : EndpointTestsBase
    {
        [Test]
        public async Task GetSeasonIdsTest()
        {
            var seasons = await DiabloApi.Season.GetSeasonIdsAsync();

            Assert.IsNotEmpty(seasons);

            var i = 1;
            foreach (var seasonId in seasons)
            {
                var seasonIdIndex = (int)seasonId;
                Assert.AreEqual(i, seasonIdIndex);
                i++;
            }
        }

        [Test]
        public async Task GetActiveSeasonIdTest()
        {
            var actualSeason = await DiabloApi.Season.GetActiveSeasonIdAsync();
            var mostRecentSeason = Enum.GetValues(typeof(SeasonId))
                .Cast<SeasonId>()
                .Max();
            Assert.AreEqual(mostRecentSeason, actualSeason);
        }

        [Test]
        public async Task GetSoloLeaderboardTest()
        {
            var leaderboardId = new SoloLeaderboardId
            {
                SeasonId = await DiabloApi.Season.GetActiveSeasonIdAsync(),
                CharacterId = CharacterKind.Wizard,
                IsHardcore = false
            };

            var leaderboard = await DiabloApi.Season.GetSoloLeaderboard(AuthenticationScope, leaderboardId);
            Assert.IsNotEmpty(leaderboard.Ranks);
        }
    }
}