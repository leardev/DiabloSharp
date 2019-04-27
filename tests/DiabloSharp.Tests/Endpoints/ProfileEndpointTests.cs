using System.Threading.Tasks;
using DiabloSharp.Models;
using NUnit.Framework;

namespace DiabloSharp.Tests.Endpoints
{
    [TestFixture]
    public class ProfileEndpointTests : EndpointTestsBase
    {
        [Test]
        public async Task GetAccountTest()
        {
            var battleTagId = new BattleTagIdentifier("Shanyen#2754");
            var account = await DiabloApi.Profile.GetAccountAsync(AuthenticationScope, battleTagId);
            Assert.IsNotNull(account);
        }

        [Test]
        public async Task GetHeroTest()
        {
            var heroId = new HeroIdentifier("Shanyen#2754", 111833443);
            var hero = await DiabloApi.Profile.GetHeroAsync(AuthenticationScope, heroId);
            Assert.IsNotNull(hero);
        }
    }
}