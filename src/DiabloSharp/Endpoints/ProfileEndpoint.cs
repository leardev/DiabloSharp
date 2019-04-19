using System.Threading.Tasks;
using DiabloSharp.Clients;
using DiabloSharp.DataTransferObjects;

namespace DiabloSharp.Endpoints
{
    public class ProfileEndpoint
    {
        public async Task<AccountDto> GetAccountAsync(IAuthenticationScope authenticationScope, string battleTag)
        {
            using (var client = new BattleNetClient(authenticationScope))
                return await client.GetAsync<AccountDto>($"d3/profile/{battleTag}/");
        }

        public async Task<HeroDto> GetHeroAsync(IAuthenticationScope authenticationScope, string battleTag, long heroId)
        {
            using (var client = new BattleNetClient(authenticationScope))
                return await client.GetAsync<HeroDto>($"d3/profile/{battleTag}/hero/{heroId}");
        }

        public async Task<DetailedHeroItemsDto> GetDetailedHeroItemsAsync(IAuthenticationScope authenticationScope, string battleTag, long heroId)
        {
            using (var client = new BattleNetClient(authenticationScope))
                return await client.GetAsync<DetailedHeroItemsDto>($"/d3/profile/{battleTag}/hero/{heroId}/items");
        }

        public async Task<DetailedFollowersDto> GetDetailedFollowerItemsAsync(IAuthenticationScope authenticationScope, string battleTag, long heroId)
        {
            using (var client = new BattleNetClient(authenticationScope))
                return await client.GetAsync<DetailedFollowersDto>($"/d3/profile/{battleTag}/hero/{heroId}/follower-items");
        }
    }
}