using System.Linq;
using System.Threading.Tasks;
using DiabloSharp.Tests.Infrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DiabloSharp.Tests.Endpoints
{
    [TestClass]
    public class FollowerEndpointTests
    {
        [TestMethod]
        public async Task GetFollowerTest()
        {
            var diabloApi = DiabloApiFactory.CreateApi();
            var authenticationScope = diabloApi.CreateAuthenticationScope();

            var follower = await diabloApi.Follower.GetFollowerAsync(authenticationScope, "templar");
            Assert.AreEqual("Templar", follower.Name);
            Assert.AreEqual("Kormac", follower.RealName);
            Assert.AreEqual("templar", follower.Slug);
            Assert.IsTrue(follower.Skills.Any());
        }
    }
}