using System.Threading.Tasks;
using DiabloSharp.DataTransferObjects;
using DiabloSharp.Models;

namespace DiabloSharp.Endpoints
{
    public class ArtisanEndpoint : EndpointBase
    {
        public async Task<ArtisanDto> GetArtisanAsync(AuthenticationScope authenticationScope, string artisanSlug)
        {
            using (var client = CreateClient(authenticationScope))
                return await client.GetAsync<ArtisanDto>($"d3/data/artisan/{artisanSlug}");
        }

        public async Task<ArtisanRecipeDto> GetRecipeAsync(AuthenticationScope authenticationScope, string artisanSlug, string recipeSlug)
        {
            using (var client = CreateClient(authenticationScope))
                return await client.GetAsync<ArtisanRecipeDto>($"d3/data/artisan/{artisanSlug}/recipe/{recipeSlug}");
        }
    }
}