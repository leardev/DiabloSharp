using System.Threading.Tasks;
using DiabloSharp.DataTransferObjects;
using DiabloSharp.Models;

namespace DiabloSharp.Endpoints
{
    public class CharacterEndpoint : EndpointBase
    {
        public async Task<CharacterClassDto> GetCharacterClassAsync(AuthenticationScope authenticationScope, string classSlug)
        {
            using (var client = CreateClient(authenticationScope))
                return await client.GetCharacterClassAsync(classSlug);
        }

        public async Task<CharacterApiSkillDto> GetApiSkillAsync(AuthenticationScope authenticationScope, string classSlug, string skillSlug)
        {
            using (var client = CreateClient(authenticationScope))
                return await client.GetApiSkillAsync(classSlug, skillSlug);
        }
    }
}