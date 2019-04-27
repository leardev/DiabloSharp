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
            var itemIdentifier = new ItemIdentifier("corrupted-ashbringer", "Unique_Sword_2H_104_x1");
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
            var itemIdentifier = new ItemIdentifier("star-emerald", "x1_Emerald_05");
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
            var itemIdentifier = new ItemIdentifier("wreath-of-lightning", "Unique_Gem_004_x1");
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
            var itemIdentifier = new ItemIdentifier("bottomless-potion-of-the-tower", "HealthPotionLegendary_01");
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
            var itemIdentifier = new ItemIdentifier("enchanting-favor", "x1_FollowerItem_Templar_Legendary_01");
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