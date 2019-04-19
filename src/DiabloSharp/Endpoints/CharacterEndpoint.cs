using System.Threading.Tasks;
using DiabloSharp.Clients;
using DiabloSharp.Models;

namespace DiabloSharp.Endpoints
{
    public class CharacterEndpoint
    {
        public async Task<CharacterClass> GetCharacterClassAsync(IAuthenticationScope authenticationScope, string classSlug)
        {
            using (var client = new BattleNetClient(authenticationScope))
                return await client.GetAsync<CharacterClass>($"/d3/data/hero/{classSlug}");
        }

        public async Task<CharacterApiSkill> GetApiSkillAsync(IAuthenticationScope authenticationScope, string classSlug, string skillSlug)
        {
            using (var client = new BattleNetClient(authenticationScope))
                return await client.GetAsync<CharacterApiSkill>($"/d3/data/hero/{classSlug}/skill/{skillSlug}");
        }
    }
}