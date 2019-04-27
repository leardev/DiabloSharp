using System.Threading.Tasks;
using DiabloSharp.Models;

namespace DiabloSharp.Endpoints
{
    public interface IArtisanEndpoint : IEndpoint
    {
        Task<Artisan> GetArtisanAsync(IAuthenticationScope authenticationScope, ArtisanIdentifier artisanId);

        Task<Recipe> GetRecipeAsync(IAuthenticationScope authenticationScope, ArtisanIdentifier artisanId, string recipeSlug);
    }
}