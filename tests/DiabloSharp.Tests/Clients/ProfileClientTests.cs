using System.Threading.Tasks;
using NUnit.Framework;

namespace DiabloSharp.Tests.Clients
{
    [TestFixture]
    internal class ProfileClientTests : ClientTestsBase
    {
        private const string BattleTag = "Shanyen-2754";

        private const long HeroId = 111833443;

        [Test]
        public async Task GetAccountTest()
        {
            var account = await Client.GetAccountAsync(BattleTag);
            Assert.That(account.BattleTag, Is.Not.Null.Or.Empty);
        }

        [Test]
        public async Task GetHeroTest()
        {
            var hero = await Client.GetHeroAsync(BattleTag, HeroId);
            Assert.AreEqual(HeroId, hero.Id);
        }

        [Test]
        public async Task GetDetailedHeroItemsTest()
        {
            var items = await Client.GetDetailedHeroItemsAsync(BattleTag, HeroId);
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
            var followerItems = await Client.GetDetailedFollowerItemsAsync(BattleTag, HeroId);
            Assert.IsNotNull(followerItems.Enchantress);
            Assert.IsNotNull(followerItems.Scoundrel);
            Assert.IsNotNull(followerItems.Templar);
        }
    }
}