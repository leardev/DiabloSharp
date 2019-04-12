using System.Threading.Tasks;
using DiabloSharp.Tests.Infrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DiabloSharp.Tests.Endpoints
{
    [TestClass]
    public class ProfileEndpointTests
    {
        [TestMethod]
        public async Task GetAccountTest()
        {
            var diabloApi = DiabloApiFactory.CreateApi();
            var authenticationScope = diabloApi.CreateAuthenticationScope();

            var account = await diabloApi.Profile.GetAccountAsync(authenticationScope, "Shanyen-2754");
            Assert.AreEqual("Shanyen#2754", account.BattleTag);
        }

        [TestMethod]
        public async Task GetHeroTest()
        {
            var diabloApi = DiabloApiFactory.CreateApi();
            var authenticationScope = diabloApi.CreateAuthenticationScope();

            var hero = await diabloApi.Profile.GetHeroAsync(authenticationScope, "Shanyen-2754", 111833443);
            Assert.AreEqual(111833443, hero.Id);
        }

        [TestMethod]
        public async Task GetHeroItemDetailsTest()
        {
            var diabloApi = DiabloApiFactory.CreateApi();
            var authenticationScope = diabloApi.CreateAuthenticationScope();

            var items = await diabloApi.Profile.GetHeroItemDetailsAsync(authenticationScope, "Shanyen-2754", 111833443);
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

        [TestMethod]
        public async Task GetHeroFollowerItemsTest()
        {
            var diabloApi = DiabloApiFactory.CreateApi();
            var authenticationScope = diabloApi.CreateAuthenticationScope();

            var followerItems = await diabloApi.Profile.GetHeroFollowerItemsAsync(authenticationScope, "Shanyen-2754", 111833443);
            Assert.IsNotNull(followerItems.Enchantress);
            Assert.IsNotNull(followerItems.Scoundrel);
            Assert.IsNotNull(followerItems.Templar);
        }
    }
}