using System.Threading.Tasks;
using DiabloSharp.Clients;
using DiabloSharp.Extensions;
using DiabloSharp.Models;
using RestSharp;

namespace DiabloSharp.Endpoints
{
    public class ActEndpoint
    {
        public async Task<ActIndex> GetActIndexAsync(IAuthenticationScope authenticationScope)
        {
            var client = new BattleNetClient(authenticationScope);
            var request = new RestRequest("/d3/data/act");
            var response = await client.ExecuteTaskAsync<ActIndex>(request);
            response.EnsureSuccess();

            return response.Data;
        }

        public async Task<Act> GetActAsync(IAuthenticationScope authenticationScope, long actId)
        {
            var client = new BattleNetClient(authenticationScope);
            var request = new RestRequest($"/d3/data/act/{actId}");
            var response = await client.ExecuteTaskAsync<Act>(request);
            response.EnsureSuccess();

            return response.Data;
        }
    }
}