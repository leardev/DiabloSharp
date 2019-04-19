using System.Threading.Tasks;
using DiabloSharp.Clients;
using DiabloSharp.Models;

namespace DiabloSharp.Endpoints
{
    public class ActEndpoint
    {
        public async Task<ActIndex> GetActIndexAsync(IAuthenticationScope authenticationScope)
        {
            using (var client = new BattleNetClient(authenticationScope))
                return await client.GetAsync<ActIndex>("/d3/data/act");
        }

        public async Task<Act> GetActAsync(IAuthenticationScope authenticationScope, long actId)
        {
            using (var client = new BattleNetClient(authenticationScope))
                return await client.GetAsync<Act>($"/d3/data/act/{actId}");
        }
    }
}