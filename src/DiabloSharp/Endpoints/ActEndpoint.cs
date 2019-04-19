using System.Threading.Tasks;
using DiabloSharp.Clients;
using DiabloSharp.DataTransferObjects;

namespace DiabloSharp.Endpoints
{
    public class ActEndpoint
    {
        public async Task<ActIndexDto> GetActIndexAsync(IAuthenticationScope authenticationScope)
        {
            using (var client = new BattleNetClient(authenticationScope))
                return await client.GetAsync<ActIndexDto>("/d3/data/act");
        }

        public async Task<ActDto> GetActAsync(IAuthenticationScope authenticationScope, long actId)
        {
            using (var client = new BattleNetClient(authenticationScope))
                return await client.GetAsync<ActDto>($"/d3/data/act/{actId}");
        }
    }
}