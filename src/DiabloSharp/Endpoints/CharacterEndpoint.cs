using System.Threading.Tasks;
using DiabloSharp.Clients;
using DiabloSharp.Extensions;
using DiabloSharp.Models;
using RestSharp;

namespace DiabloSharp.Endpoints
{
    public class CharacterEndpoint
    {
        public async Task<CharacterClass> GetCharacterClassAsync(IAuthenticationScope authenticationScope, string classSlug)
        {
            var client = new BattleNetClient(authenticationScope);
            var request = new RestRequest($"/d3/data/hero/{classSlug}");
            var response = await client.ExecuteTaskAsync<CharacterClass>(request);
            response.EnsureSuccess();

            return response.Data;
        }

        public async Task<CharacterApiSkill> GetApiSkillAsync(IAuthenticationScope authenticationScope, string classSlug, string skillSlug)
        {
            var client = new BattleNetClient(authenticationScope);
            var request = new RestRequest($"/d3/data/hero/{classSlug}/skill/{skillSlug}");
            var response = await client.ExecuteTaskAsync<CharacterApiSkill>(request);
            response.EnsureSuccess();

            return response.Data;
        }
    }
}