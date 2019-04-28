using System.Collections.Generic;
using System.Threading.Tasks;
using DiabloSharp.Models;

namespace DiabloSharp.Endpoints
{
    public interface ICharacterEndpoint : IEndpoint
    {
        Task<Character> GetCharacterAsync(IAuthenticationScope authenticationScope, CharacterId characterId);

        Task<IEnumerable<Character>> GetCharactersAsync(IAuthenticationScope authenticationScope);
    }
}