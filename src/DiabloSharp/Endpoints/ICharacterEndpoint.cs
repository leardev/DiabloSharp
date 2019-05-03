using System.Collections.Generic;
using System.Threading.Tasks;
using DiabloSharp.Models;

namespace DiabloSharp.Endpoints
{
    public interface ICharacterEndpoint : IEndpoint
    {
        Task<Character> GetCharacterAsync(IAuthenticationScope authenticationScope, CharacterKind characterKind);

        Task<IEnumerable<Character>> GetCharactersAsync(IAuthenticationScope authenticationScope);
    }
}