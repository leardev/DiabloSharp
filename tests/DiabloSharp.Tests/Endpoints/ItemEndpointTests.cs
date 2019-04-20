using System.Linq;
using System.Threading.Tasks;
using DiabloSharp.Models;
using NUnit.Framework;

namespace DiabloSharp.Tests.Endpoints
{
    [TestFixture]
    public class ItemEndpointTests : EndpointTestsBase
    {
        [Test]
        public async Task GetItemTest()
        {
            var itemId = new ItemIdentifier("Unique_Sword_2H_104_x1", "corrupted-ashbringer");

            var item = await DiabloApi.Item.GetItemAsync(AuthenticationScope, itemId);
            Assert.IsNotNull(item);
        }

        [Test]
        public async Task GetItemsTest()
        {
            var items = await DiabloApi.Item.GetItemsAsync(AuthenticationScope);
            var hqItems = items.Where(item => item.Quality == ItemQuality.Legendary || item.Quality == ItemQuality.Set).ToList();
            Assert.IsNotEmpty(items);
        }
    }
}