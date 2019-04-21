using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiabloSharp.Clients;
using DiabloSharp.Converters;
using DiabloSharp.DataTransferObjects;
using DiabloSharp.Models;

namespace DiabloSharp.Endpoints
{
    public class GemEndpoint : EndpointBase
    {
        private readonly GemConverter _gemConverter;

        private readonly List<string> _gemIndices;

        public GemEndpoint()
        {
            _gemConverter = new GemConverter();

            _gemIndices = new List<string>
            {
                "item-type/gem",
                "item-type/upgradeablejewel"
            };
        }

        public async Task<Gem> GetGemAsync(AuthenticationScope authenticationScope, ItemIdentifier itemId)
        {
            using (var client = CreateClient(authenticationScope))
            {
                var item = await client.GetItemAsync($"item/{itemId}");
                return _gemConverter.ItemToModel(item);
            }
        }

        public async Task<IEnumerable<Gem>> GetGemsAsync(AuthenticationScope authenticationScope)
        {
            using (var client = CreateClient(authenticationScope))
            {
                var processIndexToTypeTasks = _gemIndices.Select(itemType => ProcessIndexToType(client, itemType));
                var nestedItemTypes = await Task.WhenAll(processIndexToTypeTasks);
                var itemTypes = nestedItemTypes.SelectMany(types => types);
                var processTypeToItemTasks = itemTypes.Select(dto => ProcessTypeToGem(client, dto));
                var items = await Task.WhenAll(processTypeToItemTasks);

                return _gemConverter.ItemsToModel(items);
            }
        }

        private async Task<IEnumerable<ItemTypeDto>> ProcessIndexToType(BattleNetClient client, string itemType)
        {
            var itemTypes = await client.GetItemTypeAsync(itemType);
            return itemTypes;
        }

        private async Task<ItemDto> ProcessTypeToGem(BattleNetClient client, ItemTypeDto itemType)
        {
            var gem = await client.GetItemAsync(itemType.Path);
            return gem;
        }
    }
}