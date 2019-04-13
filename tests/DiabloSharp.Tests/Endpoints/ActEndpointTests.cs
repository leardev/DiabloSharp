using System.Threading.Tasks;
using DiabloSharp.Tests.Infrastructure;
using NUnit.Framework;

namespace DiabloSharp.Tests.Endpoints
{
    [TestFixture]
    public class ActEndpointTests
    {
        [Test]
        public async Task GetActsTest()
        {
            var diabloApi = DiabloApiFactory.CreateApi();
            var authenticationScope = diabloApi.CreateAuthenticationScope();

            var acts = await diabloApi.Act.GetActs(authenticationScope);
            Assert.IsNotEmpty(acts);
        }

        [Test]
        public async Task GetActTest()
        {
            var diabloApi = DiabloApiFactory.CreateApi();
            var authenticationScope = diabloApi.CreateAuthenticationScope();

            var act = await diabloApi.Act.GetAct(authenticationScope, 1);
            Assert.AreEqual(1, act.Number);
            Assert.AreEqual("act-i", act.Slug);
            Assert.AreEqual("Act I", act.Name);
            Assert.IsNotEmpty(act.Quests);
        }
    }
}