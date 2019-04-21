using System.Threading.Tasks;
using DiabloSharp.DataTransferObjects;
using DiabloSharp.Models;
using DiabloSharp.RateLimiters;

namespace DiabloSharp.Endpoints
{
    public class ItemEndpoint : EndpointBase
    {
        public ItemEndpoint(ITokenBucket tokenBucket) : base(tokenBucket)
        {
        }

        public async Task<ItemDto> GetItemAsync(AuthenticationScope authenticationScope, string itemTypePath)
        {
            using (var client = CreateClient(authenticationScope))
                return await client.GetItemAsync(itemTypePath);
        }
    }
}