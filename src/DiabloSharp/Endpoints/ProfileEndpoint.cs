using System.Threading.Tasks;
using DiabloSharp.Clients;
using DiabloSharp.Models;

namespace DiabloSharp.Endpoints
{
    public class ProfileEndpoint
    {
        public async Task<Account> GetAccountAsync(IAuthenticationScope authenticationScope, string battleTag)
        {
            using (var client = new BattleNetClient(authenticationScope))
                return await client.GetAsync<Account>($"d3/profile/{battleTag}/");
        }

        public async Task<Hero> GetHeroAsync(IAuthenticationScope authenticationScope, string battleTag, long heroId)
        {
            using (var client = new BattleNetClient(authenticationScope))
                return await client.GetAsync<Hero>($"d3/profile/{battleTag}/hero/{heroId}");
        }

        public async Task<DetailedHeroItems> GetDetailedHeroItemsAsync(IAuthenticationScope authenticationScope, string battleTag, long heroId)
        {
            using (var client = new BattleNetClient(authenticationScope))
                return await client.GetAsync<DetailedHeroItems>($"/d3/profile/{battleTag}/hero/{heroId}/items");
        }

        public async Task<DetailedFollowers> GetDetailedFollowerItemsAsync(IAuthenticationScope authenticationScope, string battleTag, long heroId)
        {
            using (var client = new BattleNetClient(authenticationScope))
                return await client.GetAsync<DetailedFollowers>($"/d3/profile/{battleTag}/hero/{heroId}/follower-items");
        }
    }
}