using System.Collections.Generic;
using System.Threading.Tasks;
using DiabloSharp.Clients;
using DiabloSharp.Extensions;
using DiabloSharp.Models;
using RestSharp;

namespace DiabloSharp.Endpoints
{
    public class ActEndpoint
    {
        public async Task<IEnumerable<Act>> GetActs(IAuthenticationScope authenticationScope)
        {
            var client = new BattleNetClient(authenticationScope);
            var request = new RestRequest("/d3/data/act");
            var response = await client.ExecuteTaskAsync<Acts>(request);
            response.EnsureSuccess();

            return response.Data.Values;
        }

        public async Task<Act> GetAct(IAuthenticationScope authenticationScope, int actId)
        {
            var client = new BattleNetClient(authenticationScope);
            var request = new RestRequest($"/d3/data/act/{actId}");
            var response = await client.ExecuteTaskAsync<Act>(request);
            response.EnsureSuccess();

            return response.Data;
        }
    }
}