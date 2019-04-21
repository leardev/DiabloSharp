using System.Threading.Tasks;
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

        public async Task<AccountDto> GetAccountAsync(AuthenticationScope authenticationScope, string battleTag)
        {
            using (var client = CreateClient(authenticationScope))
                return await client.GetAccountAsync(battleTag);
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