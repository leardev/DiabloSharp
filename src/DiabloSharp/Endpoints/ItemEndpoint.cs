using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiabloSharp.Clients;
using DiabloSharp.Converters;
using DiabloSharp.DataTransferObjects;
using DiabloSharp.Models;

namespace DiabloSharp.Endpoints
{
    public class ItemEndpoint : EndpointBase
    {
        private readonly ItemConverter _itemConverter;

        private readonly List<string> _itemIndices;

        public ItemEndpoint()
        {
            _itemConverter = new ItemConverter();

            _itemIndices = new List<string>
            {
                "item-type/amulet",
                "item-type/axe",
                "item-type/axe2h",
                "item-type/beltbarbarian",
                "item-type/boots",
                "item-type/bootsbarbarian",
                "item-type/bootscrusader",
                "item-type/bootsdemonhunter",
                "item-type/bootsmonk",
                "item-type/bootsnecromancer",
                "item-type/bootswitchdoctor",
                "item-type/bootswizard",
                "item-type/bow",
                "item-type/bracers",
                "item-type/ceremonialdagger",
                "item-type/chestarmor",
                "item-type/chestarmorbarbarian",
                "item-type/chestarmorcrusader",
                "item-type/chestarmordemonhunter",
                "item-type/chestarmormonk",
                "item-type/chestarmornecromancer",
                "item-type/chestarmorwitchdoctor",
                "item-type/chestarmorwizard",
                "item-type/cloak",
                "item-type/combatstaff",
                "item-type/crossbow",
                "item-type/crusadershield",
                "item-type/dagger",
                "item-type/fistweapon",
                "item-type/flail1h",
                "item-type/flail2h",
                "item-type/genericbelt",
                "item-type/genericchestarmor",
                "item-type/generichelm",
                "item-type/gloves",
                "item-type/glovesbarbarian",
                "item-type/glovescrusader",
                "item-type/glovesdemonhunter",
                "item-type/glovesmonk",
                "item-type/glovesnecromancer",
                "item-type/gloveswitchdoctor",
                "item-type/gloveswizard",
                "item-type/handxbow",
                "item-type/helm",
                "item-type/helmbarbarian",
                "item-type/helmcrusader",
                "item-type/helmdemonhunter",
                "item-type/helmmonk",
                "item-type/helmnecromancer",
                "item-type/helmwitchdoctor",
                "item-type/helmwizard",
                "item-type/legs",
                "item-type/legsbarbarian",
                "item-type/legscrusader",
                "item-type/legsdemonhunter",
                "item-type/legsmonk",
                "item-type/legsnecromancer",
                "item-type/legswitchdoctor",
                "item-type/legswizard",
                "item-type/mace",
                "item-type/mace2h",
                "item-type/mightyweapon1h",
                "item-type/mightyweapon2h",
                "item-type/mojo",
                "item-type/necromanceroffhand",
                "item-type/orb",
                "item-type/polearm",
                "item-type/quiver",
                "item-type/ring",
                "item-type/scythe1h",
                "item-type/scythe2h",
                "item-type/shield",
                "item-type/shoulders",
                "item-type/shouldersbarbarian",
                "item-type/shoulderscrusader",
                "item-type/shouldersdemonhunter",
                "item-type/shouldersmonk",
                "item-type/shouldersnecromancer",
                "item-type/shoulderswitchdoctor",
                "item-type/shoulderswizard",
                "item-type/spear",
                "item-type/spiritstonemonk",
                "item-type/staff",
                "item-type/sword",
                "item-type/sword2h",
                "item-type/voodoomask",
                "item-type/wand",
                "item-type/wizardhat"
            };
        }

        public async Task<Item> GetItemAsync(AuthenticationScope authenticationScope, ItemIdentifier itemId)
        {
            using (var client = CreateClient(authenticationScope))
            {
                var item = await client.GetItemAsync($"item/{itemId}");
                return _itemConverter.ItemToModel(item);
            }
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(AuthenticationScope authenticationScope)
        {
            using (var client = CreateClient(authenticationScope))
            {
                var processIndexToTypeTasks = _itemIndices.Select(itemType => ProcessIndexToType(client, itemType));
                var nestedItemTypes = await Task.WhenAll(processIndexToTypeTasks);

                var itemTypes = nestedItemTypes.SelectMany(types => types);

                var items = new List<ItemDto>();
                foreach (var itemType in itemTypes)
                {
                    var item = await client.GetItemAsync(itemType.Path);
                    items.Add(item);
                }

                /*
                var processTypeToItemTasks = itemTypes.Select(dto => ProcessTypeToItem(client, dto));
                var items = await Task.WhenAll(processTypeToItemTasks);
                */
                return _itemConverter.ItemsToModel(items)
                    .ToList();
            }
        }

        private async Task<IEnumerable<ItemTypeDto>> ProcessIndexToType(BattleNetClient client, string itemType)
        {
            var itemTypes = await client.GetItemTypeAsync(itemType);
            return itemTypes;
        }

        private async Task<ItemDto> ProcessTypeToItem(BattleNetClient client, ItemTypeDto itemType)
        {
            var item = await client.GetItemAsync(itemType.Path);
            return item;
        }
    }
}