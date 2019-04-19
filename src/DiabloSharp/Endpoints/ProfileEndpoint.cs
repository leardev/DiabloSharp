using System.Threading.Tasks;
using DiabloSharp.DataTransferObjects;
using DiabloSharp.Models;

namespace DiabloSharp.Endpoints
{
    public class ProfileEndpoint : EndpointBase
    {
        public async Task<AccountDto> GetAccountAsync(AuthenticationScope authenticationScope, string battleTag)
        {
            using (var client = CreateClient(authenticationScope))
                return await client.GetAsync<AccountDto>($"d3/profile/{battleTag}/");
        }

        public async Task<HeroDto> GetHeroAsync(AuthenticationScope authenticationScope, string battleTag, long heroId)
        {
            using (var client = CreateClient(authenticationScope))
                return await client.GetAsync<HeroDto>($"d3/profile/{battleTag}/hero/{heroId}");
        }

        public async Task<DetailedHeroItemsDto> GetDetailedHeroItemsAsync(AuthenticationScope authenticationScope, string battleTag, long heroId)
        {
            using (var client = CreateClient(authenticationScope))
                return await client.GetAsync<DetailedHeroItemsDto>($"/d3/profile/{battleTag}/hero/{heroId}/items");
        }

        public async Task<DetailedFollowersDto> GetDetailedFollowerItemsAsync(AuthenticationScope authenticationScope, string battleTag, long heroId)
        {
            using (var client = CreateClient(authenticationScope))
                return await client.GetAsync<DetailedFollowersDto>($"/d3/profile/{battleTag}/hero/{heroId}/follower-items");
        }
    }
}