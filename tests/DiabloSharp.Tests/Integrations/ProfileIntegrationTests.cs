using System.Linq;
using System.Threading.Tasks;
using DiabloSharp.Models;
using DiabloSharp.Tests.Infrastructure;
using NUnit.Framework;

namespace DiabloSharp.Tests.Integrations
{
    [TestFixture]
    public class ProfileIntegrationTests
    {
        private const string BattleTag = "Shanyen-2754";

        private IAuthenticationScope _authenticationScope;

        [OneTimeSetUp]
        public async Task SetupFixture()
        {
            var diabloApi = DiabloApiFactory.CreateApi();
            _authenticationScope = await diabloApi.CreateAuthenticationScopeAsync();
        }

        [Test]
        [Ignore("Disabled until rate limiting (100 requests per second | 36,000 requests per hour) is implemented.")]
        public async Task IntegrationTest()
        {
            var diabloApi = DiabloApiFactory.CreateApi();
            var account = await diabloApi.Profile.GetAccountAsync(_authenticationScope, BattleTag);

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

        private async Task<DetailedHeroItems> ProcessHeroToItems(string battleTag, AccountHero accountHero)
        {
            var diabloApi = DiabloApiFactory.CreateApi();
            return await diabloApi.Profile.GetDetailedHeroItemsAsync(_authenticationScope, battleTag, accountHero.Id);
        }

        private async Task<DetailedFollowers> ProcessHeroToFollowerItems(string battleTag, AccountHero accountHero)
        {
            var diabloApi = DiabloApiFactory.CreateApi();
            return await diabloApi.Profile.GetDetailedFollowerItemsAsync(_authenticationScope, battleTag, accountHero.Id);
        }

        private async Task<Hero> ProcessHero(string battleTag, AccountHero accountHero)
        {
            var diabloApi = DiabloApiFactory.CreateApi();
            return await diabloApi.Profile.GetHeroAsync(_authenticationScope, battleTag, accountHero.Id);
        }
    }
}