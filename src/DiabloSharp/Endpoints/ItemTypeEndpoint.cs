using System.Collections.Generic;
using System.Threading.Tasks;
using DiabloSharp.DataTransferObjects;
using DiabloSharp.Models;

namespace DiabloSharp.Endpoints
{
    public class ItemTypeEndpoint : EndpointBase
    {
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