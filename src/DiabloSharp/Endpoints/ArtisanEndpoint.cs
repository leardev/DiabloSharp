using System.Threading.Tasks;
using DiabloSharp.Clients;
using DiabloSharp.DataTransferObjects;

namespace DiabloSharp.Endpoints
{
    public class ArtisanEndpoint
    {
        public async Task<ArtisanDto> GetArtisanAsync(IAuthenticationScope authenticationScope, string artisanSlug)
        {
            using (var client = new BattleNetClient(authenticationScope))
                return await client.GetAsync<ArtisanDto>($"d3/data/artisan/{artisanSlug}");
        }

        public async Task<ArtisanRecipeDto> GetRecipeAsync(IAuthenticationScope authenticationScope, string artisanSlug, string recipeSlug)
        {
            using (var client = new BattleNetClient(authenticationScope))
                return await client.GetAsync<ArtisanRecipeDto>($"d3/data/artisan/{artisanSlug}/recipe/{recipeSlug}");
        }
    }
}