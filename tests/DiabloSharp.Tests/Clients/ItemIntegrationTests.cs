using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DiabloSharp.DataTransferObjects;
using NUnit.Framework;

namespace DiabloSharp.Tests.Clients
{
    [TestFixture]
    internal class ItemIntegrationTests : ClientTestsBase
    {
        private List<string> _blacklist;

        [OneTimeSetUp]
        public void SetupFixture()
        {
            _blacklist = new List<string>
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
        }

        [Test]
        public async Task IntegrationTest()
        {
            var sw = Stopwatch.StartNew();
            var itemTypeIndices = await Client.GetItemTypeIndexAsync();

            var processIndexToTypeTasks = itemTypeIndices.Select(ProcessIndexToType);
            var nestedItemTypes = await Task.WhenAll(processIndexToTypeTasks);
            var itemTypes = nestedItemTypes.SelectMany(types => types);

            /* remove unresolvable items */
            itemTypes = itemTypes.Where(type => !_blacklist.Contains(type.Path));

            var processTypeToItemTasks = itemTypes.Select(ProcessTypeToItem);
            var items = await Task.WhenAll(processTypeToItemTasks);
            sw.Stop();
            foreach (var item in items)
                Assert.That(item.Id, Is.Not.Null.Or.Empty);
        }

        private async Task<IEnumerable<ItemTypeDto>> ProcessIndexToType(ItemTypeIndexDto itemTypeIndex)
        {
            var itemTypes = await Client.GetItemTypeAsync(itemTypeIndex.Path);
            return itemTypes;
        }

        private async Task<ItemDto> ProcessTypeToItem(ItemTypeDto itemType)
        {
            var item = await Client.GetItemAsync(itemType.Path);
            return item;
        }
    }
}