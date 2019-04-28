using System.Threading.Tasks;
using DiabloSharp.Models;
using NUnit.Framework;

namespace DiabloSharp.Tests.Endpoints
{
    [TestFixture]
    public class FollowerEndpointTests : EndpointTestsBase
    {
        [Test]
        public async Task GetFollowerTest()
        {
            var follower = await DiabloApi.Follower.GetFollowerAsync(AuthenticationScope, FollowerId.Templar);
            Assert.IsNotNull(follower);
        }
    }
}