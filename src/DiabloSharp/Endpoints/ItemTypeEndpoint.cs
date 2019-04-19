using System.Collections.Generic;
using System.Threading.Tasks;
using DiabloSharp.Clients;
using DiabloSharp.DataTransferObjects;
using DiabloSharp.Extensions;
using RestSharp;

namespace DiabloSharp.Endpoints
{
    public class ItemTypeEndpoint
    {
        public async Task<IEnumerable<ItemTypeIndexDto>> GetItemTypeIndexAsync(IAuthenticationScope authenticationScope)
        {
            var client = new BattleNetClient(authenticationScope);
            var request = new RestRequest("d3/data/item-type");
            var response = await client.ExecuteTaskAsync<List<ItemTypeIndexDto>>(request);
            response.EnsureSuccess();

            return response.Data;
        }

        public async Task<IEnumerable<ItemTypeDto>> GetItemTypeAsync(IAuthenticationScope authenticationScope, string itemTypeIndexPath)
        {
            var client = new BattleNetClient(authenticationScope);
            var request = new RestRequest($"d3/data/{itemTypeIndexPath}");
            var response = await client.ExecuteTaskAsync<List<ItemTypeDto>>(request);
            response.EnsureSuccess();

            return response.Data;
        }
    }
}