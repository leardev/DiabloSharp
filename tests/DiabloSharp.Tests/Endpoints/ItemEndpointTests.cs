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

        [Test]
        public async Task GetGemTest()
        {
            var itemIdentifier = new ItemIdentifier("x1_Emerald_05", "star-emerald");
            var item = await DiabloApi.Item.GetGemAsync(AuthenticationScope, itemIdentifier);
            Assert.IsNotNull(item);
        }

        [Test]
        public async Task GetGemsTest()
        {
            var items = await DiabloApi.Item.GetGemsAsync(AuthenticationScope);
            Assert.IsNotEmpty(items);
        }

        [Test]
        public async Task GetLegendaryGemTest()
        {
            var itemIdentifier = new ItemIdentifier("Unique_Gem_004_x1", "wreath-of-lightning");
            var item = await DiabloApi.Item.GetLegendaryGemAsync(AuthenticationScope, itemIdentifier);
            Assert.IsNotNull(item);
        }

        [Test]
        public async Task GetLegendaryGemsTest()
        {
            var items = await DiabloApi.Item.GetLegendaryGemsAsync(AuthenticationScope);
            Assert.IsNotEmpty(items);
        }

        [Test]
        public async Task GetLegendaryPotionTest()
        {
            var itemIdentifier = new ItemIdentifier("HealthPotionLegendary_01", "bottomless-potion-of-the-tower");
            var item = await DiabloApi.Item.GetLegendaryPotionAsync(AuthenticationScope, itemIdentifier);
            Assert.IsNotNull(item);
        }

        [Test]
        public async Task GetLegendaryPotionsTest()
        {
            var items = await DiabloApi.Item.GetLegendaryPotionsAsync(AuthenticationScope);
            Assert.IsNotEmpty(items);
        }

        [Test]
        public async Task GetFollowerTokenTest()
        {
            var itemIdentifier = new ItemIdentifier("x1_FollowerItem_Templar_Legendary_01", "enchanting-favor");
            var item = await DiabloApi.Item.GetFollowerTokenAsync(AuthenticationScope, itemIdentifier);
            Assert.IsNotNull(item);
        }

        [Test]
        public async Task GetFollowerTokensTest()
        {
            var items = await DiabloApi.Item.GetFollowerTokensAsync(AuthenticationScope);
            Assert.IsNotEmpty(items);
        }
    }
}