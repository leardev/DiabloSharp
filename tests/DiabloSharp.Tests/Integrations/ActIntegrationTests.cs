using System.Threading.Tasks;
using DiabloSharp.Tests.Infrastructure;
using NUnit.Framework;

namespace DiabloSharp.Tests.Integrations
{
    [TestFixture]
    public class ActIntegrationTests
    {
        [Test]
        public async Task IntegrationTest()
        {
            var diabloApi = DiabloApiFactory.CreateApi();
            var authenticationScope = diabloApi.CreateAuthenticationScope();

            var actIndex = await diabloApi.Act.GetActIndexAsync(authenticationScope);
            foreach (var act in actIndex.Acts)
            {
                var x = await diabloApi.Act.GetActAsync(authenticationScope, act.Id);
                Assert.AreEqual(act.Id, x.Id);
            }
        }
    }
}