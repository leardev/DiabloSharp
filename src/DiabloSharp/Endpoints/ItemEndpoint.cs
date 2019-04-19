using System.Threading.Tasks;
using DiabloSharp.DataTransferObjects;
using DiabloSharp.Models;

namespace DiabloSharp.Endpoints
{
    public class ItemEndpoint : EndpointBase
    {
        public async Task<ItemDto> GetItemAsync(AuthenticationScope authenticationScope, string itemTypePath)
        {
            using (var client = CreateClient(authenticationScope))
                return await client.GetAsync<ItemDto>($"d3/data/{itemTypePath}");
        }
    }
}