using System.Threading.Tasks;
using DiabloSharp.Clients;
using DiabloSharp.Extensions;
using DiabloSharp.Models;
using RestSharp;

namespace DiabloSharp.Endpoints
{
    public class ProfileEndpoint
    {
        public async Task<Account> GetAccountAsync(IAuthenticationScope authenticationScope, string battleTag)
        {
            var client = new BattleNetClient(authenticationScope);
            var request = new RestRequest($"d3/profile/{battleTag}/");
            var response = await client.ExecuteTaskAsync<Account>(request);
            response.EnsureSuccess();

            return response.Data;
        }

        public async Task<Hero> GetHeroAsync(IAuthenticationScope authenticationScope, string battleTag, long heroId)
        {
            var client = new BattleNetClient(authenticationScope);
            var request = new RestRequest($"d3/profile/{battleTag}/hero/{heroId}");
            var response = await client.ExecuteTaskAsync<Hero>(request);
            response.EnsureSuccess();

            return response.Data;
        }

        public async Task<DetailedHeroItems> GetDetailedHeroItemsAsync(IAuthenticationScope authenticationScope, string battleTag, long heroId)
        {
            var client = new BattleNetClient(authenticationScope);
            var request = new RestRequest($"/d3/profile/{battleTag}/hero/{heroId}/items");
            var response = await client.ExecuteTaskAsync<DetailedHeroItems>(request);
            response.EnsureSuccess();

            return response.Data;
        }

        public async Task<DetailedFollowers> GetDetailedFollowerItemsAsync(IAuthenticationScope authenticationScope, string battleTag, long heroId)
        {
            var client = new BattleNetClient(authenticationScope);
            var request = new RestRequest($"/d3/profile/{battleTag}/hero/{heroId}/follower-items");
            var response = await client.ExecuteTaskAsync<DetailedFollowers>(request);
            response.EnsureSuccess();

            return response.Data;
        }
    }
}