using System.Threading.Tasks;
using DiabloSharp.Tests.Infrastructure;
using NUnit.Framework;

namespace DiabloSharp.Tests.Endpoints
{
    [TestFixture]
    public class ProfileEndpointTests
    {
        private const string BattleTag = "Shanyen-2754";

        private const long HeroId = 111833443;

        [Test]
        public async Task GetAccountTest()
        {
            var diabloApi = DiabloApiFactory.CreateApi();
            var authenticationScope = diabloApi.CreateAuthenticationScope();

            var account = await diabloApi.Profile.GetAccountAsync(authenticationScope, BattleTag);
            Assert.That(account.BattleTag, Is.Not.Null.Or.Empty);
        }

        [Test]
        public async Task GetHeroTest()
        {
            var diabloApi = DiabloApiFactory.CreateApi();
            var authenticationScope = diabloApi.CreateAuthenticationScope();

            var hero = await diabloApi.Profile.GetHeroAsync(authenticationScope, BattleTag, HeroId);
            Assert.AreEqual(HeroId, hero.Id);
        }

        [Test]
        public async Task GetDetailedHeroItemsTest()
        {
            var diabloApi = DiabloApiFactory.CreateApi();
            var authenticationScope = diabloApi.CreateAuthenticationScope();

            var items = await diabloApi.Profile.GetDetailedHeroItemsAsync(authenticationScope, BattleTag, HeroId);
            Assert.IsNotNull(items.Head);
            Assert.IsNotNull(items.Neck);
            Assert.IsNotNull(items.Torso);
            Assert.IsNotNull(items.Shoulders);
            Assert.IsNotNull(items.Legs);
            Assert.IsNotNull(items.Waist);
            Assert.IsNotNull(items.Hands);
            Assert.IsNotNull(items.Bracers);
            Assert.IsNotNull(items.Feet);
            Assert.IsNotNull(items.MainHand);
            Assert.IsNotNull(items.OffHand);
        }

        [Test]
        public async Task GetDetailedFollowerItemsTest()
        {
            var diabloApi = DiabloApiFactory.CreateApi();
            var authenticationScope = diabloApi.CreateAuthenticationScope();

            var followerItems = await diabloApi.Profile.GetDetailedFollowerItemsAsync(authenticationScope, BattleTag, HeroId);
            Assert.IsNotNull(followerItems.Enchantress);
            Assert.IsNotNull(followerItems.Scoundrel);
            Assert.IsNotNull(followerItems.Templar);
        }
    }
}