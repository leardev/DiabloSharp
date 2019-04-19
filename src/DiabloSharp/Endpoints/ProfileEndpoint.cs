using System.Threading.Tasks;
using DiabloSharp.Clients;
using DiabloSharp.DataTransferObjects;
using DiabloSharp.Extensions;
using RestSharp;

namespace DiabloSharp.Endpoints
{
    public class ProfileEndpoint
    {
        public async Task<AccountDto> GetAccountAsync(IAuthenticationScope authenticationScope, string battleTag)
        {
            var client = new BattleNetClient(authenticationScope);
            var request = new RestRequest($"d3/profile/{battleTag}/");
            var response = await client.ExecuteTaskAsync<AccountDto>(request);
            response.EnsureSuccess();

            return response.Data;
        }

        public async Task<HeroDto> GetHeroAsync(IAuthenticationScope authenticationScope, string battleTag, long heroId)
        {
            var client = new BattleNetClient(authenticationScope);
            var request = new RestRequest($"d3/profile/{battleTag}/hero/{heroId}");
            var response = await client.ExecuteTaskAsync<HeroDto>(request);
            response.EnsureSuccess();

            return response.Data;
        }

        public async Task<DetailedHeroItemsDto> GetDetailedHeroItemsAsync(IAuthenticationScope authenticationScope, string battleTag, long heroId)
        {
            var client = new BattleNetClient(authenticationScope);
            var request = new RestRequest($"/d3/profile/{battleTag}/hero/{heroId}/items");
            var response = await client.ExecuteTaskAsync<DetailedHeroItemsDto>(request);
            response.EnsureSuccess();

            return response.Data;
        }

        public async Task<DetailedFollowersDto> GetDetailedFollowerItemsAsync(IAuthenticationScope authenticationScope, string battleTag, long heroId)
        {
            var client = new BattleNetClient(authenticationScope);
            var request = new RestRequest($"/d3/profile/{battleTag}/hero/{heroId}/follower-items");
            var response = await client.ExecuteTaskAsync<DetailedFollowersDto>(request);
            response.EnsureSuccess();

            return response.Data;
        }
    }
}