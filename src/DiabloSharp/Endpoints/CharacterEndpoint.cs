using System.Threading.Tasks;
using DiabloSharp.Clients;
using DiabloSharp.DataTransferObjects;
using DiabloSharp.Extensions;
using RestSharp;

namespace DiabloSharp.Endpoints
{
    public class CharacterEndpoint
    {
        public async Task<CharacterClassDto> GetCharacterClassAsync(IAuthenticationScope authenticationScope, string classSlug)
        {
            var client = new BattleNetClient(authenticationScope);
            var request = new RestRequest($"/d3/data/hero/{classSlug}");
            var response = await client.ExecuteTaskAsync<CharacterClassDto>(request);
            response.EnsureSuccess();

            return response.Data;
        }

        public async Task<CharacterApiSkillDto> GetApiSkillAsync(IAuthenticationScope authenticationScope, string classSlug, string skillSlug)
        {
            var client = new BattleNetClient(authenticationScope);
            var request = new RestRequest($"/d3/data/hero/{classSlug}/skill/{skillSlug}");
            var response = await client.ExecuteTaskAsync<CharacterApiSkillDto>(request);
            response.EnsureSuccess();

            return response.Data;
        }
    }
}