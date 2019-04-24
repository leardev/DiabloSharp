using System.Threading.Tasks;
using DiabloSharp.Converters;
using DiabloSharp.DataTransferObjects;
using DiabloSharp.Models;
using DiabloSharp.RateLimiters;

namespace DiabloSharp.Endpoints
{
    public class ProfileEndpoint : EndpointBase
    {
        public ProfileEndpoint(ITokenBucket tokenBucket) : base(tokenBucket)
        {
        }

        public async Task<Account> GetAccountAsync(AuthenticationScope authenticationScope, BattleTagIdentifier battleTagId)
        {
            var converter = new AccountConverter();
            using (var client = CreateClient(authenticationScope))
            {
                var account = await client.GetAccountAsync($"{battleTagId.Name}-{battleTagId.Index}");
                return converter.AccountToModel(account);
            }
        }

        public async Task<HeroDto> GetHeroAsync(AuthenticationScope authenticationScope, string battleTag, long heroId)
        {
            using (var client = CreateClient(authenticationScope))
                return await client.GetHeroAsync(battleTag, heroId);
        }

        public async Task<DetailedHeroItemsDto> GetDetailedHeroItemsAsync(AuthenticationScope authenticationScope, string battleTag, long heroId)
        {
            using (var client = CreateClient(authenticationScope))
                return await client.GetDetailedHeroItemsAsync(battleTag, heroId);
        }

        public async Task<DetailedFollowersDto> GetDetailedFollowerItemsAsync(AuthenticationScope authenticationScope, string battleTag, long heroId)
        {
            using (var client = CreateClient(authenticationScope))
                return await client.GetDetailedFollowerItemsAsync(battleTag, heroId);
        }
    }
}