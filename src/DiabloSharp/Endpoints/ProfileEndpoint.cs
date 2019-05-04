using System.Threading.Tasks;
using DiabloSharp.Mappers;
using DiabloSharp.Models;
using DiabloSharp.RateLimiters;

namespace DiabloSharp.Endpoints
{
    internal class ProfileEndpoint : Endpoint,
                                     IProfileEndpoint
    {
        public ProfileEndpoint(ITokenBucket tokenBucket)
            : base(tokenBucket)
        {
        }

        public async Task<Account> GetAccountAsync(IAuthenticationScope authenticationScope, BattleTagId battleTagId)
        {
            var mapper = new AccountMapper();
            var battleTag = $"{battleTagId.Name}-{battleTagId.Index}";

            using (var client = CreateClient(authenticationScope))
            {
                var account = await client.GetAccountAsync(battleTag);
                return mapper.Map(account);
            }
        }

        public async Task<Hero> GetHeroAsync(IAuthenticationScope authenticationScope, HeroId heroId)
        {
            var battleTag = $"{heroId.BattleTag.Name}-{heroId.BattleTag.Index}";

            using (var client = CreateClient(authenticationScope))
            {
                var hero = await client.GetHeroAsync(battleTag, heroId.Id);
                var items = await client.GetDetailedHeroItemsAsync(battleTag, heroId.Id);
                var followerItems = await client.GetDetailedFollowerItemsAsync(battleTag, heroId.Id);

                var mapper = new HeroMapper(heroId, items, followerItems);
                return mapper.Map(hero);
            }
        }
    }
}