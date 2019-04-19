using System.Threading.Tasks;
using DiabloSharp.Clients;
using DiabloSharp.DataTransferObjects;
using DiabloSharp.Extensions;
using RestSharp;

namespace DiabloSharp.Endpoints
{
    public class ActEndpoint
    {
        public async Task<ActIndexDto> GetActIndexAsync(IAuthenticationScope authenticationScope)
        {
            var client = new BattleNetClient(authenticationScope);
            var request = new RestRequest("/d3/data/act");
            var response = await client.ExecuteTaskAsync<ActIndexDto>(request);
            response.EnsureSuccess();

            return response.Data;
        }

        public async Task<ActDto> GetActAsync(IAuthenticationScope authenticationScope, long actId)
        {
            var client = new BattleNetClient(authenticationScope);
            var request = new RestRequest($"/d3/data/act/{actId}");
            var response = await client.ExecuteTaskAsync<ActDto>(request);
            response.EnsureSuccess();

            return response.Data;
        }
    }
}