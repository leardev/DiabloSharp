using System.Threading.Tasks;
using DiabloSharp.Tests.Infrastructure;
using NUnit.Framework;

namespace DiabloSharp.Tests.Endpoints
{
    [TestFixture]
    public class EraEndpointTests
    {
        [Test]
        public async Task GetEraIndexTest()
        {
            var diabloApi = DiabloApiFactory.CreateApi();
            var authenticationScope = diabloApi.CreateAuthenticationScope();

            var seasons = await diabloApi.Era.GetEraIndexAsync(authenticationScope);
            Assert.That(seasons.Links.Self.Href, Is.Not.Null.Or.Empty);
            Assert.IsNotEmpty(seasons.Eras);
        }

        [Test]
        public async Task GetEraTest()
        {
            var diabloApi = DiabloApiFactory.CreateApi();
            var authenticationScope = diabloApi.CreateAuthenticationScope();

            var season = await diabloApi.Era.GetEraAsync(authenticationScope, 1);
            Assert.IsNotEmpty(season.Leaderboards);
        }

        [Test]
        public async Task GetEraLeaderboardTest()
        {
            var diabloApi = DiabloApiFactory.CreateApi();
            var authenticationScope = diabloApi.CreateAuthenticationScope();

            var leaderboardDetail = await diabloApi.Era.GetEraLeaderboardAsync(authenticationScope, 1, "rift-barbarian");
            Assert.IsNotEmpty(leaderboardDetail.Columns);
        }
    }
}