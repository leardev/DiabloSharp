using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiabloSharp.Models;
using DiabloSharp.Tests.Infrastructure;
using NUnit.Framework;

namespace DiabloSharp.Tests.Integrations
{
    [TestFixture]
    public class ItemIntegrationTests
    {
        private IAuthenticationScope _authenticationScope;

        private List<string> _blacklist;

        [OneTimeSetUp]
        public async Task SetupFixture()
        {
            var diabloApi = DiabloApiFactory.CreateApi();
            _authenticationScope = await diabloApi.CreateAuthenticationScopeAsync();
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
        [Ignore("Disabled until rate limiting (100 requests per second | 36,000 requests per hour) is implemented.")]
        public async Task IntegrationTest()
        {
            var diabloApi = DiabloApiFactory.CreateApi();
            var itemTypeIndices = await diabloApi.ItemType.GetItemTypeIndexAsync(_authenticationScope);

            var processIndexToTypeTasks = itemTypeIndices.Select(ProcessIndexToType);
            var nestedItemTypes = await Task.WhenAll(processIndexToTypeTasks);
            var itemTypes = nestedItemTypes.SelectMany(types => types);

            /* remove unresolvable items */
            itemTypes = itemTypes.Where(type => !_blacklist.Contains(type.Path));

            var processTypeToItemTasks = itemTypes.Select(ProcessTypeToItem);
            var items = await Task.WhenAll(processTypeToItemTasks);

            foreach (var item in items)
                Assert.That(item.Id, Is.Not.Null.Or.Empty);
        }

        private async Task<IEnumerable<ItemType>> ProcessIndexToType(ItemTypeIndex itemTypeIndex)
        {
            var diabloApi = DiabloApiFactory.CreateApi();
            var itemTypes = await diabloApi.ItemType.GetItemTypeAsync(_authenticationScope, itemTypeIndex.Path);
            return itemTypes;
        }

        private async Task<Item> ProcessTypeToItem(ItemType itemType)
        {
            var diabloApi = DiabloApiFactory.CreateApi();
            var item = await diabloApi.Item.GetItemAsync(_authenticationScope, itemType.Path);
            return item;
        }
    }
}