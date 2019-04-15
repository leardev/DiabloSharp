using System.Threading.Tasks;
using DiabloSharp.Clients;
using DiabloSharp.Extensions;
using DiabloSharp.Models;
using RestSharp;

namespace DiabloSharp.Endpoints
{
    public class ArtisanEndpoint
    {
        public async Task<Artisan> GetArtisanAsync(IAuthenticationScope authenticationScope, string artisanSlug)
        {
            var client = new BattleNetClient(authenticationScope);
            var request = new RestRequest($"d3/data/artisan/{artisanSlug}");
            var response = await client.ExecuteTaskAsync<Artisan>(request);
            response.EnsureSuccess();

            return response.Data;
        }

        public async Task<ArtisanRecipe> GetRecipeAsync(IAuthenticationScope authenticationScope, string artisanSlug, string recipeSlug)
        {
            var client = new BattleNetClient(authenticationScope);
            var request = new RestRequest($"d3/data/artisan/{artisanSlug}/recipe/{recipeSlug}");
            var response = await client.ExecuteTaskAsync<ArtisanRecipe>(request);
            response.EnsureSuccess();

            return response.Data;
        }
    }
}