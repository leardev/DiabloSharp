using System.Collections.Generic;
using System.Threading.Tasks;
using DiabloSharp.Models;

namespace DiabloSharp.Endpoints
{
    public interface IArtisanEndpoint : IEndpoint
    {
        Task<Artisan> GetArtisanAsync(IAuthenticationScope authenticationScope, ArtisanId artisanId);

        Task<IEnumerable<Artisan>> GetArtisansAsync(IAuthenticationScope authenticationScope);

        Task<Recipe> GetRecipeAsync(IAuthenticationScope authenticationScope, RecipeId recipeId);
    }
}