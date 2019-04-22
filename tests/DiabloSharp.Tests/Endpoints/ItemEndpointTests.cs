using System.Threading.Tasks;
using DiabloSharp.Models;
using NUnit.Framework;

namespace DiabloSharp.Tests.Endpoints
{
    [TestFixture]
    public class ItemEndpointTests : EndpointTestsBase
    {
        [Test]
        public async Task GetItemEquipmentTest()
        {
            var itemIdentifier = new ItemIdentifier("Unique_Sword_2H_104_x1", "corrupted-ashbringer");
            var item = await DiabloApi.Item.GetEquipmentAsync(AuthenticationScope, itemIdentifier);
            Assert.IsNotNull(item);
        }

        [Test]
        public async Task GetItemEquipmentsTest()
        {
            var items = await DiabloApi.Item.GetEquipmentsAsync(AuthenticationScope);
            Assert.IsNotEmpty(items);
        }
    }
}