using System.Threading.Tasks;
using DiabloSharp.Converters;
using DiabloSharp.Models;
using DiabloSharp.RateLimiters;

namespace DiabloSharp.Endpoints
{
    internal class ArtisanEndpoint : Endpoint,
                                     IArtisanEndpoint
    {
        private readonly ArtisanConverter _artisanConverter;

        public ArtisanEndpoint(ITokenBucket tokenBucket) : base(tokenBucket)
        {
            _artisanConverter = new ArtisanConverter();
        }

        public async Task<Artisan> GetArtisanAsync(IAuthenticationScope authenticationScope, ArtisanIdentifier artisanId)
        {
            var artisanSlug = artisanId.ToString().ToLower();

            using (var client = CreateClient(authenticationScope))
            {
                var artisan = await client.GetArtisanAsync(artisanSlug);
                return _artisanConverter.ArtisanToModel(artisanId, artisan);
            }
        }

        public async Task<Recipe> GetRecipeAsync(IAuthenticationScope authenticationScope, ArtisanIdentifier artisanId, string recipeSlug)
        {
            var artisanSlug = artisanId.ToString().ToLower();

            using (var client = CreateClient(authenticationScope))
            {
                var recipe = await client.GetRecipeAsync(artisanSlug, recipeSlug);
                return _artisanConverter.RecipeToModel(recipe);
            }
        }
    }
}