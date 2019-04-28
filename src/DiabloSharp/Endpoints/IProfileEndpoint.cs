using System.Threading.Tasks;
using DiabloSharp.Models;

namespace DiabloSharp.Endpoints
{
    public interface IProfileEndpoint : IEndpoint
    {
        Task<Account> GetAccountAsync(IAuthenticationScope authenticationScope, BattleTagId battleTagId);

        Task<Hero> GetHeroAsync(IAuthenticationScope authenticationScope, HeroId heroId);
    }
}