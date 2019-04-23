using System.Threading.Tasks;
using NUnit.Framework;

namespace DiabloSharp.Tests.Clients
{
    [TestFixture]
    internal class ActIntegrationTests : ClientTestsBase
    {
        [Test]
        public async Task IntegrationTest()
        {
            var actIndex = await Client.GetActIndexAsync();
            foreach (var act in actIndex.Acts)
            {
                var x = await Client.GetActAsync(act.Id);
                Assert.AreEqual(act.Id, x.Id);
            }
        }
    }
}