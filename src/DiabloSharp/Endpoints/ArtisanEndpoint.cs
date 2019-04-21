using System.Threading.Tasks;
using DiabloSharp.DataTransferObjects;
using DiabloSharp.Models;
using DiabloSharp.RateLimiters;

namespace DiabloSharp.Endpoints
{
    public class ArtisanEndpoint : EndpointBase
    {
        public ArtisanEndpoint(ITokenBucket tokenBucket) : base(tokenBucket)
        {
        }

        public async Task<ArtisanDto> GetArtisanAsync(AuthenticationScope authenticationScope, string artisanSlug)
        {
            using (var client = CreateClient(authenticationScope))
                return await client.GetArtisanAsync(artisanSlug);
        }

        public async Task<ArtisanRecipeDto> GetRecipeAsync(AuthenticationScope authenticationScope, string artisanSlug, string recipeSlug)
        {
            using (var client = CreateClient(authenticationScope))
                return await client.GetRecipeAsync(artisanSlug, recipeSlug);
        }
    }
}