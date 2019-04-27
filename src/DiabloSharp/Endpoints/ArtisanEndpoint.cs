using System.Threading.Tasks;
using DiabloSharp.Mappers;
using DiabloSharp.Models;
using DiabloSharp.RateLimiters;

namespace DiabloSharp.Endpoints
{
    internal class ArtisanEndpoint : Endpoint,
                                     IArtisanEndpoint
    {
        public ArtisanEndpoint(ITokenBucket tokenBucket) : base(tokenBucket)
        {
        }

        public async Task<Artisan> GetArtisanAsync(IAuthenticationScope authenticationScope, ArtisanIdentifier artisanId)
        {
            var mapper = new ArtisanMapper();
            var artisanSlug = artisanId.ToString().ToLower();

            using (var client = CreateClient(authenticationScope))
            {
                var artisan = await client.GetArtisanAsync(artisanSlug);
                return mapper.Map(artisan);
            }
        }

        public async Task<Recipe> GetRecipeAsync(IAuthenticationScope authenticationScope, ArtisanIdentifier artisanId, string recipeSlug)
        {
            var mapper = new RecipeMapper();
            var artisanSlug = artisanId.ToString().ToLower();

            using (var client = CreateClient(authenticationScope))
            {
                var recipe = await client.GetRecipeAsync(artisanSlug, recipeSlug);
                return mapper.Map(recipe);
            }
        }
    }
}