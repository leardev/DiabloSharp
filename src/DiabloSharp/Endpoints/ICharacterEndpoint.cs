using System.Collections.Generic;
using System.Threading.Tasks;
using DiabloSharp.Models;

namespace DiabloSharp.Endpoints
{
    public interface ICharacterEndpoint : IEndpoint
    {
        Task<CharacterClass> GetCharacterClassAsync(IAuthenticationScope authenticationScope, CharacterClassIdentifier characterClassId);

        Task<IEnumerable<CharacterClass>> GetCharacterClassesAsync(IAuthenticationScope authenticationScope);
    }
}