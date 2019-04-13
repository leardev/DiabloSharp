using System.Threading.Tasks;
using DiabloSharp.Tests.Infrastructure;
using NUnit.Framework;

namespace DiabloSharp.Tests.Endpoints
{
    [TestFixture]
    public class SeasonEndpointTests
    {
        [Test]
        public async Task GetSeasonsTest()
        {
            var diabloApi = DiabloApiFactory.CreateApi();
            var authenticationScope = diabloApi.CreateAuthenticationScope();

            var seasons = await diabloApi.Season.GetSeasons(authenticationScope);
            Assert.IsNotEmpty(seasons.Links.Self.Href);
            Assert.IsNotEmpty(seasons.Season);
        }

        [Test]
        public async Task GetSeasonTest()
        {
            var diabloApi = DiabloApiFactory.CreateApi();
            var authenticationScope = diabloApi.CreateAuthenticationScope();

            var season = await diabloApi.Season.GetSeason(authenticationScope, 16);
            Assert.IsNotEmpty(season.Leaderboards);
        }

        [Test]
        public async Task GetSeasonLeaderboardDetailTest()
        {
            var diabloApi = DiabloApiFactory.CreateApi();
            var authenticationScope = diabloApi.CreateAuthenticationScope();

            var leaderboardDetail = await diabloApi.Season.GetSeasonLeaderboardDetail(authenticationScope, 1, "achievement-points");
            Assert.IsNotEmpty(leaderboardDetail.Column);
        }
    }
}