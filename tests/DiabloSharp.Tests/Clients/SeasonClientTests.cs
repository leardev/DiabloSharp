using System.Threading.Tasks;
using NUnit.Framework;

namespace DiabloSharp.Tests.Clients
{
    [TestFixture]
    internal class SeasonClientTests : ClientTestsBase
    {
        [Test]
        public async Task GetSeasonIndexTest()
        {
            var seasons = await Client.GetSeasonIndexAsync();
            Assert.That(seasons.Links.Self.Href, Is.Not.Null.Or.Empty);
            Assert.IsNotEmpty(seasons.Seasons);
        }

        [Test]
        public async Task GetSeasonTest()
        {
            var season = await Client.GetSeasonAsync(16);
            Assert.IsNotEmpty(season.Leaderboards);
        }

        [Test]
        public async Task GetSeasonLeaderboardTest()
        {
            var leaderboardDetail = await Client.GetSeasonLeaderboardAsync(1, "achievement-points");
            Assert.IsNotEmpty(leaderboardDetail.Columns);
        }
    }
}