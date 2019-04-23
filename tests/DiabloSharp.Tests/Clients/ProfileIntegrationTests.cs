using System.Linq;
using System.Threading.Tasks;
using DiabloSharp.DataTransferObjects;
using NUnit.Framework;

namespace DiabloSharp.Tests.Clients
{
    [TestFixture]
    internal class ProfileIntegrationTests : ClientTestsBase
    {
        private const string BattleTag = "Shanyen-2754";

        [Test]
        public async Task IntegrationTest()
        {
            var account = await Client.GetAccountAsync(BattleTag);

            var detailedHeroItemsTasks = account.Heroes.Select(accountHero => ProcessHeroToItems(BattleTag, accountHero));
            var detailedHeroItems = await Task.WhenAll(detailedHeroItemsTasks);
            Assert.IsNotEmpty(detailedHeroItems);

            var detailedFollowerItemsTasks = account.Heroes.Select(accountHero => ProcessHeroToFollowerItems(BattleTag, accountHero));
            var detailedFollowerItems = await Task.WhenAll(detailedFollowerItemsTasks);
            Assert.IsNotEmpty(detailedFollowerItems);

            var heroesTasks = account.Heroes.Select(accountHero => ProcessHero(BattleTag, accountHero));
            var heroes = await Task.WhenAll(heroesTasks);
            Assert.IsNotEmpty(heroes);
        }

        private async Task<DetailedHeroItemsDto> ProcessHeroToItems(string battleTag, AccountHeroDto accountHero)
        {
            return await Client.GetDetailedHeroItemsAsync(battleTag, accountHero.Id);
        }

        private async Task<DetailedFollowersDto> ProcessHeroToFollowerItems(string battleTag, AccountHeroDto accountHero)
        {
            return await Client.GetDetailedFollowerItemsAsync(battleTag, accountHero.Id);
        }

        private async Task<HeroDto> ProcessHero(string battleTag, AccountHeroDto accountHero)
        {
            return await Client.GetHeroAsync(battleTag, accountHero.Id);
        }
    }
}