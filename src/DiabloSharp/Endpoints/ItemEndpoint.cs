using System.Threading.Tasks;
using DiabloSharp.Clients;
using DiabloSharp.Extensions;
using DiabloSharp.Models;
using RestSharp;

namespace DiabloSharp.Endpoints
{
    public class ItemEndpoint
    {
        public async Task<Item> GetItemAsync(IAuthenticationScope authenticationScope, string itemPath)
        {
            var client = new BattleNetClient(authenticationScope);
            var request = new RestRequest($"d3/data/{itemPath}");
            var response = await client.ExecuteTaskAsync<Item>(request);
            response.EnsureSuccess();

            return response.Data;
        }
    }
}