using System;
using System.Threading.Tasks;
using DiabloSharp.Tests.Infrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DiabloSharp.Tests.Endpoints
{
    [TestClass]
    public class ItemEndpointTests
    {
        [TestMethod]
        public async Task GetItemTest()
        {
            var diabloApi = DiabloApiFactory.CreateApi();
            var authenticationScope = diabloApi.CreateAuthenticationScope();

            var item = await diabloApi.Item.GetItemAsync(authenticationScope, "item/corrupted-ashbringer-Unique_Sword_2H_104_x1");
            Assert.IsTrue(item != null);
            Assert.AreEqual("Corrupted Ashbringer", item.Name);
        }

        [TestMethod]
        public async Task GetInvalidItemsTest()
        {
            var itemPaths = new[]
            {
                "item/mysterious-box-The Adventurer's Box",
                "item/town-portal-stone-TownPortalStone",
                "item/a-gift-ConsoleFriendGift",
                "item/1h-mystery-weapon-PH_1HWeapon",
                "item/2h-mystery-weapon-PH_2HWeapon",
                "item/gold-Gold4",
                "item/gold-Gold3",
                "item/gold-Gold2",
                "item/gold-Gold1",
                "item/shard-Shard",
                "item/debug-transmog-plan-Debug_Transmog_Plan",
                "item/greater-shard-GreaterShard"
            };

            var diabloApi = DiabloApiFactory.CreateApi();
            var authenticationScope = diabloApi.CreateAuthenticationScope();
            foreach (var itemPath in itemPaths)
                await Assert.ThrowsExceptionAsync<Exception>(async () => await diabloApi.Item.GetItemAsync(authenticationScope, itemPath));
        }
    }
}