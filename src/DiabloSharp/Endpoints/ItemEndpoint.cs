using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiabloSharp.Converters;
using DiabloSharp.Models;
using DiabloSharp.RateLimiters;

namespace DiabloSharp.Endpoints
{
    internal class ItemEndpoint : Endpoint,
                                  IItemEndpoint
    {
        private readonly string[] _equipmentIndices;

        private readonly string[] _followerTokenIndices;

        public ItemEndpoint(ITokenBucket tokenBucket) : base(tokenBucket)
        {
            #region equipmentIndices

            _equipmentIndices = new[]
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

            #endregion

            #region followerTokenIndices

            _followerTokenIndices = new[]
            {
                "item-type/scoundrelspecial",
                "item-type/templarspecial",
                "item-type/enchantressspecial"
            };

            #endregion
        }

        public Task<ItemEquipment> GetEquipmentAsync(IAuthenticationScope authenticationScope, ItemIdentifier itemIdentifier)
        {
            var converter = new ItemEquipmentConverter();
            return GetItem(authenticationScope, converter, itemIdentifier);
        }

        public Task<IEnumerable<ItemEquipment>> GetEquipmentsAsync(IAuthenticationScope authenticationScope)
        {
            var converter = new ItemEquipmentConverter();
            return GetItems(authenticationScope, converter, _equipmentIndices);
        }

        public Task<ItemGem> GetGemAsync(IAuthenticationScope authenticationScope, ItemIdentifier itemIdentifier)
        {
            var converter = new ItemGemConverter();
            return GetItem(authenticationScope, converter, itemIdentifier);
        }

        public Task<IEnumerable<ItemGem>> GetGemsAsync(IAuthenticationScope authenticationScope)
        {
            var converter = new ItemGemConverter();
            return GetItems(authenticationScope, converter, "item-type/gem");
        }

        public Task<ItemLegendaryGem> GetLegendaryGemAsync(IAuthenticationScope authenticationScope, ItemIdentifier itemIdentifier)
        {
            var converter = new ItemLegendaryGemConverter();
            return GetItem(authenticationScope, converter, itemIdentifier);
        }

        public Task<IEnumerable<ItemLegendaryGem>> GetLegendaryGemsAsync(IAuthenticationScope authenticationScope)
        {
            var converter = new ItemLegendaryGemConverter();
            return GetItems(authenticationScope, converter, "item-type/upgradeablejewel");
        }

        public Task<ItemLegendaryPotion> GetLegendaryPotionAsync(IAuthenticationScope authenticationScope, ItemIdentifier itemIdentifier)
        {
            var converter = new ItemLegendaryPotionConverter();
            return GetItem(authenticationScope, converter, itemIdentifier);
        }

        public Task<IEnumerable<ItemLegendaryPotion>> GetLegendaryPotionsAsync(IAuthenticationScope authenticationScope)
        {
            var converter = new ItemLegendaryPotionConverter();
            return GetItems(authenticationScope, converter, "item-type/healthpotion");
        }

        public Task<ItemFollowerToken> GetFollowerTokenAsync(IAuthenticationScope authenticationScope, ItemIdentifier itemIdentifier)
        {
            var converter = new ItemFollowerTokenConverter();
            return GetItem(authenticationScope, converter, itemIdentifier);
        }

        public Task<IEnumerable<ItemFollowerToken>> GetFollowerTokensAsync(IAuthenticationScope authenticationScope)
        {
            var converter = new ItemFollowerTokenConverter();
            return GetItems(authenticationScope, converter, _followerTokenIndices);
        }

        private async Task<T> GetItem<T>(IAuthenticationScope authenticationScope, ItemConverter<T> converter, ItemIdentifier itemIdentifier) where T : Item, new()
        {
            using (var client = CreateClient(authenticationScope))
            {
                var item = await client.GetItemAsync($"item/{itemIdentifier}");
                return converter.ItemToModel(item);
            }
        }

        private async Task<IEnumerable<T>> GetItems<T>(IAuthenticationScope authenticationScope, ItemConverter<T> converter, params string[] itemTypeIndices) where T : Item, new()
        {
            using (var client = CreateClient(authenticationScope))
            {
                var processItemTypeIndicesToItemTypesTasks = itemTypeIndices.Select(async itemTypeIndex => await client.GetItemTypeAsync(itemTypeIndex))
                    .ToList();
                var nestedItemTypes = await Task.WhenAll(processItemTypeIndicesToItemTypesTasks);
                var itemTypes = nestedItemTypes.SelectMany(types => types);

                var processItemTypesToItemsTasks = itemTypes.Select(async itemType => await client.GetItemAsync(itemType.Path))
                    .ToList();
                var items = await Task.WhenAll(processItemTypesToItemsTasks);

                return converter.ItemsToModel(items)
                    .ToList();
            }
        }
    }
}