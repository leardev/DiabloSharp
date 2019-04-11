using System.Collections.Generic;
using System.Threading.Tasks;
using DiabloSharp.Clients;
using DiabloSharp.Extensions;
using DiabloSharp.Models;
using RestSharp;

namespace DiabloSharp.Endpoints
{
    public class ItemTypeEndpoint
    {
        public async Task<IEnumerable<ItemTypeIndex>> GetItemTypeIndexAsync(IAuthenticationScope authenticationScope)
        {
            var client = new BattleNetClient(authenticationScope);
            var request = new RestRequest("d3/data/item-type");
            var response = await client.ExecuteTaskAsync<List<ItemTypeIndex>>(request);
            response.EnsureSuccess();

            return response.Data;
        }

        public async Task<IEnumerable<ItemType>> GetItemTypeAsync(IAuthenticationScope authenticationScope, string itemTypeSlug)
        {
            var client = new BattleNetClient(authenticationScope);
            var request = new RestRequest($"d3/data/item-type/{itemTypeSlug}");
            var response = await client.ExecuteTaskAsync<List<ItemType>>(request);
            response.EnsureSuccess();

            return response.Data;
        }
    }
}