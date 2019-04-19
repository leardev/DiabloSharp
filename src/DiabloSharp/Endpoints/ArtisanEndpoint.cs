using System.Threading.Tasks;
using DiabloSharp.Clients;
using DiabloSharp.DataTransferObjects;
using DiabloSharp.Extensions;
using RestSharp;

namespace DiabloSharp.Endpoints
{
    public class ArtisanEndpoint
    {
        public async Task<ArtisanDto> GetArtisanAsync(IAuthenticationScope authenticationScope, string artisanSlug)
        {
            var client = new BattleNetClient(authenticationScope);
            var request = new RestRequest($"d3/data/artisan/{artisanSlug}");
            var response = await client.ExecuteTaskAsync<ArtisanDto>(request);
            response.EnsureSuccess();

            return response.Data;
        }

        public async Task<ArtisanRecipeDto> GetRecipeAsync(IAuthenticationScope authenticationScope, string artisanSlug, string recipeSlug)
        {
            var client = new BattleNetClient(authenticationScope);
            var request = new RestRequest($"d3/data/artisan/{artisanSlug}/recipe/{recipeSlug}");
            var response = await client.ExecuteTaskAsync<ArtisanRecipeDto>(request);
            response.EnsureSuccess();

            return response.Data;
        }
    }
}