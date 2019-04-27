using System.Threading.Tasks;
using DiabloSharp.Converters;
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

        public async Task<Account> GetAccountAsync(AuthenticationScope authenticationScope, BattleTagIdentifier battleTagId)
        {
            var converter = new AccountConverter();
            var battleTag = $"{battleTagId.Name}-{battleTagId.Index}";

            using (var client = CreateClient(authenticationScope))
            {
                var account = await client.GetAccountAsync(battleTag);
                return converter.AccountToModel(account);
            }
        }

        public async Task<Hero> GetHeroAsync(AuthenticationScope authenticationScope, HeroIdentifier heroId)
        {
            var converter = new HeroConverter();
            var battleTag = $"{heroId.BattleTag.Name}-{heroId.BattleTag.Index}";

            using (var client = CreateClient(authenticationScope))
            {
                var hero = await client.GetHeroAsync(battleTag, heroId.Id);
                return converter.HeroToModel(heroId, hero);
            }
        }
    }
}