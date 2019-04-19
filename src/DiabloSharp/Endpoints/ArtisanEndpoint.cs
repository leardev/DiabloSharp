using System.Threading.Tasks;
using DiabloSharp.Clients;
using DiabloSharp.Models;

namespace DiabloSharp.Endpoints
{
    public class ArtisanEndpoint
    {
        public async Task<Artisan> GetArtisanAsync(IAuthenticationScope authenticationScope, string artisanSlug)
        {
            using (var client = new BattleNetClient(authenticationScope))
                return await client.GetAsync<Artisan>($"d3/data/artisan/{artisanSlug}");
        }

        public async Task<ArtisanRecipe> GetRecipeAsync(IAuthenticationScope authenticationScope, string artisanSlug, string recipeSlug)
        {
            using (var client = new BattleNetClient(authenticationScope))
                return await client.GetAsync<ArtisanRecipe>($"d3/data/artisan/{artisanSlug}/recipe/{recipeSlug}");
        }
    }
}