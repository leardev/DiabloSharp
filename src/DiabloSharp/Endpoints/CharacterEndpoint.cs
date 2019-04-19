using System.Threading.Tasks;
using DiabloSharp.Clients;
using DiabloSharp.DataTransferObjects;

namespace DiabloSharp.Endpoints
{
    public class CharacterEndpoint
    {
        public async Task<CharacterClassDto> GetCharacterClassAsync(IAuthenticationScope authenticationScope, string classSlug)
        {
            using (var client = new BattleNetClient(authenticationScope))
                return await client.GetAsync<CharacterClassDto>($"/d3/data/hero/{classSlug}");
        }

        public async Task<CharacterApiSkillDto> GetApiSkillAsync(IAuthenticationScope authenticationScope, string classSlug, string skillSlug)
        {
            using (var client = new BattleNetClient(authenticationScope))
                return await client.GetAsync<CharacterApiSkillDto>($"/d3/data/hero/{classSlug}/skill/{skillSlug}");
        }
    }
}