using System.Collections.Generic;
using System.Threading.Tasks;
using DiabloSharp.Clients;
using DiabloSharp.Models;

namespace DiabloSharp.Endpoints
{
    public class ItemTypeEndpoint
    {
        public async Task<IEnumerable<ItemTypeIndex>> GetItemTypeIndexAsync(IAuthenticationScope authenticationScope)
        {
            using (var client = new BattleNetClient(authenticationScope))
                return await client.GetAsync<List<ItemTypeIndex>>("d3/data/item-type");
        }

        public async Task<IEnumerable<ItemType>> GetItemTypeAsync(IAuthenticationScope authenticationScope, string itemTypeIndexPath)
        {
            using (var client = new BattleNetClient(authenticationScope))
                return await client.GetAsync<List<ItemType>>($"d3/data/{itemTypeIndexPath}");
        }
    }
}