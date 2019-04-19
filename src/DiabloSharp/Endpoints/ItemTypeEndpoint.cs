using System.Collections.Generic;
using System.Threading.Tasks;
using DiabloSharp.Clients;
using DiabloSharp.DataTransferObjects;

namespace DiabloSharp.Endpoints
{
    public class ItemTypeEndpoint
    {
        public async Task<IEnumerable<ItemTypeIndexDto>> GetItemTypeIndexAsync(IAuthenticationScope authenticationScope)
        {
            using (var client = new BattleNetClient(authenticationScope))
                return await client.GetAsync<List<ItemTypeIndexDto>>("d3/data/item-type");
        }

        public async Task<IEnumerable<ItemTypeDto>> GetItemTypeAsync(IAuthenticationScope authenticationScope, string itemTypeIndexPath)
        {
            using (var client = new BattleNetClient(authenticationScope))
                return await client.GetAsync<List<ItemTypeDto>>($"d3/data/{itemTypeIndexPath}");
        }
    }
}