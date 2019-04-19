using System.Threading.Tasks;
using DiabloSharp.Clients;
using DiabloSharp.DataTransferObjects;
using DiabloSharp.Extensions;
using RestSharp;

namespace DiabloSharp.Endpoints
{
    public class ItemEndpoint
    {
        public async Task<ItemDto> GetItemAsync(IAuthenticationScope authenticationScope, string itemTypePath)
        {
            var client = new BattleNetClient(authenticationScope);
            var request = new RestRequest($"d3/data/{itemTypePath}");
            var response = await client.ExecuteTaskAsync<ItemDto>(request);
            response.EnsureSuccess();

            return response.Data;
        }
    }
}