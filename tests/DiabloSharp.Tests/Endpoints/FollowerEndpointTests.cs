using System.Threading.Tasks;
using DiabloSharp.Tests.Infrastructure;
using NUnit.Framework;

namespace DiabloSharp.Tests.Endpoints
{
    [TestFixture]
    public class FollowerEndpointTests
    {
        [Test]
        public async Task GetFollowerTest()
        {
            var diabloApi = DiabloApiFactory.CreateApi();
            var authenticationScope = diabloApi.CreateAuthenticationScope();

            var follower = await diabloApi.Follower.GetFollowerAsync(authenticationScope, "templar");
            Assert.AreEqual("Templar", follower.Name);
            Assert.AreEqual("Kormac", follower.RealName);
            Assert.AreEqual("templar", follower.Slug);
            Assert.IsNotEmpty(follower.Skills);
        }
    }
}