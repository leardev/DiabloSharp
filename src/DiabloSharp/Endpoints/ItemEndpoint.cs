using System.Threading.Tasks;
using DiabloSharp.Clients;
using DiabloSharp.DataTransferObjects;

namespace DiabloSharp.Endpoints
{
    public class ItemEndpoint
    {
        public async Task<ItemDto> GetItemAsync(IAuthenticationScope authenticationScope, string itemTypePath)
        {
            using (var client = new BattleNetClient(authenticationScope))
                return await client.GetAsync<ItemDto>($"d3/data/{itemTypePath}");
        }
    }
}