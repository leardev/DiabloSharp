using System.Threading.Tasks;
using DiabloSharp.Models;

namespace DiabloSharp.Endpoints
{
    public interface IProfileEndpoint : IEndpoint
    {
        Task<Account> GetAccountAsync(IAuthenticationScope authenticationScope, BattleTagIdentifier battleTagId);

        Task<Hero> GetHeroAsync(IAuthenticationScope authenticationScope, HeroIdentifier heroId);
    }
}