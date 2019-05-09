using System.Threading.Tasks;
using NUnit.Framework;

namespace DiabloSharp.Tests.Clients
{
    [TestFixture]
    [Ignore("https://us.battle.net/forums/en/bnet/topic/20771557003")]
    internal class EraClientTests : ClientTestsBase
    {
        [Test]
        public async Task GetEraIndexTest()
        {
            var seasons = await Client.GetEraIndexAsync();
            Assert.That(seasons.Links.Self.Href, Is.Not.Null.Or.Empty);
            Assert.IsNotEmpty(seasons.Eras);
        }

        [Test]
        public async Task GetEraTest()
        {
            var season = await Client.GetEraAsync(1);
            Assert.IsNotEmpty(season.Leaderboards);
        }

        [Test]
        public async Task GetEraLeaderboardTest()
        {
            var leaderboardDetail = await Client.GetEraLeaderboardAsync(1, "rift-barbarian");
            Assert.IsNotEmpty(leaderboardDetail.Columns);
        }
    }
}