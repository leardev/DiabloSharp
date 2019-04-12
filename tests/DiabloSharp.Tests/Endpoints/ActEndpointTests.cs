using System.Linq;
using System.Threading.Tasks;
using DiabloSharp.Tests.Infrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DiabloSharp.Tests.Endpoints
{
    [TestClass]
    public class ActEndpointTests
    {
        [TestMethod]
        public async Task GetActsTest()
        {
            var diabloApi = DiabloApiFactory.CreateApi();
            var authenticationScope = diabloApi.CreateAuthenticationScope();

            var acts = await diabloApi.Act.GetActs(authenticationScope);
            Assert.IsTrue(acts.Any());
        }

        [TestMethod]
        public async Task GetActTest()
        {
            var diabloApi = DiabloApiFactory.CreateApi();
            var authenticationScope = diabloApi.CreateAuthenticationScope();

            var act = await diabloApi.Act.GetAct(authenticationScope, 1);
            Assert.AreEqual(1, act.Number);
            Assert.AreEqual("act-i", act.Slug);
            Assert.AreEqual("Act I", act.Name);
            Assert.IsTrue(act.Quests.Any());
        }
    }
}