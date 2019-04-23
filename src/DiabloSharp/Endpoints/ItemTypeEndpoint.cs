using System.Collections.Generic;
using System.Threading.Tasks;
using DiabloSharp.DataTransferObjects;
using DiabloSharp.Models;
using DiabloSharp.RateLimiters;

namespace DiabloSharp.Endpoints
{
    public class ItemTypeEndpoint : EndpointBase
    {
        public ItemTypeEndpoint(ITokenBucket tokenBucket) : base(tokenBucket)
        {
        }

        public async Task<IEnumerable<ItemTypeIndexDto>> GetItemTypeIndexAsync(AuthenticationScope authenticationScope)
        {
            using (var client = CreateClient(authenticationScope))
                return await client.GetItemTypeIndexAsync();
        }

        public async Task<IEnumerable<ItemTypeDto>> GetItemTypeAsync(AuthenticationScope authenticationScope, string itemTypeIndexPath)
        {
            using (var client = CreateClient(authenticationScope))
                return await client.GetItemTypeAsync(itemTypeIndexPath);
        }
    }
}