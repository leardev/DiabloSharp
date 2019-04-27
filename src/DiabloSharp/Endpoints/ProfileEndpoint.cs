using System.Threading.Tasks;
using DiabloSharp.Mappers;
using DiabloSharp.Models;
using DiabloSharp.RateLimiters;

namespace DiabloSharp.Endpoints
{
    internal class ProfileEndpoint : Endpoint,
                                     IProfileEndpoint
    {
        public ProfileEndpoint(ITokenBucket tokenBucket) : base(tokenBucket)
        {
        }

        public async Task<Account> GetAccountAsync(IAuthenticationScope authenticationScope, BattleTagIdentifier battleTagId)
        {
            var mapper = new AccountMapper();
            var battleTag = $"{battleTagId.Name}-{battleTagId.Index}";

            using (var client = CreateClient(authenticationScope))
            {
                var account = await client.GetAccountAsync(battleTag);
                return mapper.Map(account);
            }
        }

        public async Task<Hero> GetHeroAsync(IAuthenticationScope authenticationScope, HeroIdentifier heroId)
        {
            var mapper = new HeroMapper { HeroId = heroId };
            var battleTag = $"{heroId.BattleTag.Name}-{heroId.BattleTag.Index}";

            using (var client = CreateClient(authenticationScope))
            {
                var hero = await client.GetHeroAsync(battleTag, heroId.Id);
                return mapper.Map(hero);
            }
        }
    }
}