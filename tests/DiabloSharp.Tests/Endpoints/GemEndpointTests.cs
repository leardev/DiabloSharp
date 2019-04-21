using System.Linq;
using System.Threading.Tasks;
using DiabloSharp.Models;
using NUnit.Framework;

namespace DiabloSharp.Tests.Endpoints
{
    [TestFixture]
    public class GemEndpointTests : EndpointTestsBase
    {
        [Test]
        public async Task GetGemTest()
        {
            var gemId = new ItemIdentifier("Unique_Gem_014_x1", "boon-of-the-hoarder");
            var gem = await DiabloApi.Gem.GetGemAsync(AuthenticationScope, gemId);
            Assert.IsNotNull(gem);
        }

        [Test]
        public async Task GetGemsTest()
        {
            var gems = await DiabloApi.Gem.GetGemsAsync(AuthenticationScope);
            var legendaryGems = gems.Where(item => item.Quality == ItemQuality.Legendary).ToList();
            Assert.IsNotEmpty(legendaryGems);
        }
    }
}