using System.Threading.Tasks;
using DiabloSharp.Models;
using NUnit.Framework;

namespace DiabloSharp.Tests.Endpoints
{
    [TestFixture]
    public class ActEndpointTests : EndpointTestsBase
    {
        [Test]
        public async Task GetActIndexTest()
        {
            var acts = await DiabloApi.Act.GetActsAsync(AuthenticationScope);
            Assert.IsNotEmpty(acts);
        }

        [Test]
        public async Task GetActAsyncTest()
        {
            var act = await DiabloApi.Act.GetActAsync(AuthenticationScope, ActIdentifier.Act1);
            Assert.IsNotNull(act);
        }
    }
}