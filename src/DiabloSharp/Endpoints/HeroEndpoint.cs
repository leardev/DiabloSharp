using System.Threading.Tasks;
using DiabloSharp.Clients;
using DiabloSharp.Extensions;
using DiabloSharp.Models;
using RestSharp;

namespace DiabloSharp.Endpoints
{
    public class HeroEndpoint
    {
        public async Task<HeroClass> GetHeroClassAsync(IAuthenticationScope authenticationScope, string classSlug)
        {
            var client = new BattleNetClient(authenticationScope);
            var request = new RestRequest($"/d3/data/hero/{classSlug}");
            var response = await client.ExecuteTaskAsync<HeroClass>(request);
            response.EnsureSuccess();

            return response.Data;
        }

        public async Task<RunesBySkill> GetRunesBySkillAsync(IAuthenticationScope authenticationScope, string classSlug, string skillSlug)
        {
            var client = new BattleNetClient(authenticationScope);
            var request = new RestRequest($"/d3/data/hero/{classSlug}/skill/{skillSlug}");
            var response = await client.ExecuteTaskAsync<RunesBySkill>(request);
            response.EnsureSuccess();

            return response.Data;
        }
    }
}