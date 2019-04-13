using System.Threading.Tasks;
using DiabloSharp.Tests.Infrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace DiabloSharp.Tests.Endpoints
{
    [TestClass]
    public class SeasonEndpointTests
    {
        [TestMethod]
        public async Task GetSeasonsTest()
        {
            var diabloApi = DiabloApiFactory.CreateApi();
            var authenticationScope = diabloApi.CreateAuthenticationScope();

            var seasons = await diabloApi.Season.GetSeasons(authenticationScope);
            Assert.IsFalse(string.IsNullOrEmpty(seasons.Links.Self.Href));
            Assert.IsTrue(seasons.Season.Any());
        }

        [TestMethod]
        public async Task GetSeasonTest()
        {
            var diabloApi = DiabloApiFactory.CreateApi();
            var authenticationScope = diabloApi.CreateAuthenticationScope();

            var season = await diabloApi.Season.GetSeason(authenticationScope, 16);
            Assert.IsTrue(season.Leaderboards.Any());
        }

        [TestMethod]
        public async Task GetSeasonLeaderboardDetailTest()
        {
            var diabloApi = DiabloApiFactory.CreateApi();
            var authenticationScope = diabloApi.CreateAuthenticationScope();

            var leaderboardDetail = await diabloApi.Season.GetSeasonLeaderboardDetail(authenticationScope, 1, "achievement-points");
            Assert.IsTrue(leaderboardDetail.Column.Any());
        }
    }
}