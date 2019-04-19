using System.Threading.Tasks;
using DiabloSharp.Tests.Infrastructure;
using NUnit.Framework;

namespace DiabloSharp.Tests.Integrations
{
    [TestFixture]
    public class ActIntegrationTests
    {
        [Test]
        [Ignore("Disabled until rate limiting (100 requests per second | 36,000 requests per hour) is implemented.")]
        public async Task IntegrationTest()
        {
            var diabloApi = DiabloApiFactory.CreateApi();
            var authenticationScope = await diabloApi.CreateAuthenticationScopeAsync();

            var actIndex = await diabloApi.Act.GetActIndexAsync(authenticationScope);
            foreach (var act in actIndex.Acts)
            {
                var x = await diabloApi.Act.GetActAsync(authenticationScope, act.Id);
                Assert.AreEqual(act.Id, x.Id);
            }
        }
    }
}