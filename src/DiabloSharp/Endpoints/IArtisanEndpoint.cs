using System.Collections.Generic;
using System.Threading.Tasks;
using DiabloSharp.Models;

namespace DiabloSharp.Endpoints
{
    public interface IArtisanEndpoint : IEndpoint
    {
        Task<Artisan> GetArtisanAsync(IAuthenticationScope authenticationScope, ArtisanIdentifier artisanId);

        Task<IEnumerable<Artisan>> GetArtisansAsync(IAuthenticationScope authenticationScope);

        Task<Recipe> GetRecipeAsync(IAuthenticationScope authenticationScope, RecipeIdentifier recipeId);
    }
}