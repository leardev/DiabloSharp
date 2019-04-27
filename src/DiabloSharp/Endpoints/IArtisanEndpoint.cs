using System.Threading.Tasks;
using DiabloSharp.Models;

namespace DiabloSharp.Endpoints
{
    public interface IArtisanEndpoint : IEndpoint
    {
        Task<Artisan> GetArtisanAsync(AuthenticationScope authenticationScope, ArtisanIdentifier artisanId);

        Task<Recipe> GetRecipeAsync(AuthenticationScope authenticationScope, ArtisanIdentifier artisanId, string recipeSlug);
    }
}