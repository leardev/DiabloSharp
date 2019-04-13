using System.Linq;
using System.Threading.Tasks;
using DiabloSharp.Tests.Infrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DiabloSharp.Tests.Endpoints
{
    [TestClass]
    public class EraEndpointTests
    {
        [TestMethod]
        public async Task GetErasTest()
        {
            var diabloApi = DiabloApiFactory.CreateApi();
            var authenticationScope = diabloApi.CreateAuthenticationScope();

            var seasons = await diabloApi.Era.GetEras(authenticationScope);
            Assert.IsFalse(string.IsNullOrEmpty(seasons.Links.Self.Href));
            Assert.IsTrue(seasons.Era.Any());
        }

        [TestMethod]
        public async Task GetEraTest()
        {
            var diabloApi = DiabloApiFactory.CreateApi();
            var authenticationScope = diabloApi.CreateAuthenticationScope();

            var season = await diabloApi.Era.GetEra(authenticationScope, 1);
            Assert.IsTrue(season.Leaderboards.Any());
        }

        [TestMethod]
        public async Task GetEraLeaderboardDetailTest()
        {
            var diabloApi = DiabloApiFactory.CreateApi();
            var authenticationScope = diabloApi.CreateAuthenticationScope();

            var leaderboardDetail = await diabloApi.Era.GetEraLeaderboardDetail(authenticationScope, 1, "rift-barbarian");
            Assert.IsTrue(leaderboardDetail.Column.Any());
        }
    }
}