using System.Threading.Tasks;
using DiabloSharp.Tests.Infrastructure;
using NUnit.Framework;

namespace DiabloSharp.Tests.Endpoints
{
    [TestFixture]
    public class SeasonEndpointTests
    {
        [Test]
        public async Task GetSeasonIndexTest()
        {
            var diabloApi = DiabloApiFactory.CreateApi();
            var authenticationScope = await diabloApi.CreateAuthenticationScopeAsync();

            var seasons = await diabloApi.Season.GetSeasonIndexAsync(authenticationScope);
            Assert.That(seasons.Links.Self.Href, Is.Not.Null.Or.Empty);
            Assert.IsNotEmpty(seasons.Seasons);
        }

        [Test]
        public async Task GetSeasonTest()
        {
            var diabloApi = DiabloApiFactory.CreateApi();
            var authenticationScope = await diabloApi.CreateAuthenticationScopeAsync();

            var season = await diabloApi.Season.GetSeasonAsync(authenticationScope, 16);
            Assert.IsNotEmpty(season.Leaderboards);
        }

        [Test]
        public async Task GetSeasonLeaderboardTest()
        {
            var diabloApi = DiabloApiFactory.CreateApi();
            var authenticationScope = await diabloApi.CreateAuthenticationScopeAsync();

            var leaderboardDetail = await diabloApi.Season.GetSeasonLeaderboardAsync(authenticationScope, 1, "achievement-points");
            Assert.IsNotEmpty(leaderboardDetail.Columns);
        }
    }
}