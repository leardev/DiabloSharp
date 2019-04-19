using System.Threading.Tasks;
using DiabloSharp.DataTransferObjects;
using DiabloSharp.Models;

namespace DiabloSharp.Endpoints
{
    public class ActEndpoint : EndpointBase
    {
        public async Task<ActIndexDto> GetActIndexAsync(AuthenticationScope authenticationScope)
        {
            using (var client = CreateClient(authenticationScope))
                return await client.GetAsync<ActIndexDto>("/d3/data/act");
        }

        public async Task<ActDto> GetActAsync(AuthenticationScope authenticationScope, long actId)
        {
            using (var client = CreateClient(authenticationScope))
                return await client.GetAsync<ActDto>($"/d3/data/act/{actId}");
        }
    }
}