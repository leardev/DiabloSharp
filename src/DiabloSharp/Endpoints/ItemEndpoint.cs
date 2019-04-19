using System.Threading.Tasks;
using DiabloSharp.Clients;
using DiabloSharp.Models;

namespace DiabloSharp.Endpoints
{
    public class ItemEndpoint
    {
        public async Task<Item> GetItemAsync(IAuthenticationScope authenticationScope, string itemTypePath)
        {
            using (var client = new BattleNetClient(authenticationScope))
                return await client.GetAsync<Item>($"d3/data/{itemTypePath}");
        }
    }
}