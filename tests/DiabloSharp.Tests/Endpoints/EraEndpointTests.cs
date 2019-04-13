using System.Threading.Tasks;
using DiabloSharp.Tests.Infrastructure;
using NUnit.Framework;

namespace DiabloSharp.Tests.Endpoints
{
    [TestFixture]
    public class EraEndpointTests
    {
        [Test]
        public async Task GetErasTest()
        {
            var diabloApi = DiabloApiFactory.CreateApi();
            var authenticationScope = diabloApi.CreateAuthenticationScope();

            var seasons = await diabloApi.Era.GetEras(authenticationScope);
            Assert.IsNotEmpty(seasons.Links.Self.Href);
            Assert.IsNotEmpty(seasons.Era);
        }

        [Test]
        public async Task GetEraTest()
        {
            var diabloApi = DiabloApiFactory.CreateApi();
            var authenticationScope = diabloApi.CreateAuthenticationScope();

            var season = await diabloApi.Era.GetEra(authenticationScope, 1);
            Assert.IsNotEmpty(season.Leaderboards);
        }

        [Test]
        public async Task GetEraLeaderboardDetailTest()
        {
            var diabloApi = DiabloApiFactory.CreateApi();
            var authenticationScope = diabloApi.CreateAuthenticationScope();

            var leaderboardDetail = await diabloApi.Era.GetEraLeaderboardDetail(authenticationScope, 1, "rift-barbarian");
            Assert.IsNotEmpty(leaderboardDetail.Column);
        }
    }
}