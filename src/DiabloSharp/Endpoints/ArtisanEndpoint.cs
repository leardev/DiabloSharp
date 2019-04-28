using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiabloSharp.Helpers;
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

        public async Task<Artisan> GetArtisanAsync(IAuthenticationScope authenticationScope, ArtisanId artisanId)
        {
            var mapper = new ArtisanMapper();
            var artisanSlug = artisanId.ToString().ToLower();

            using (var client = CreateClient(authenticationScope))
            {
                var artisan = await client.GetArtisanAsync(artisanSlug);
                return mapper.Map(artisan);
            }
        }

        public async Task<IEnumerable<Artisan>> GetArtisansAsync(IAuthenticationScope authenticationScope)
        {
            var artisanIds = Enum.GetValues(typeof(ArtisanId))
                .Cast<ArtisanId>()
                .ToList();

            var artisanTasks = artisanIds.Select(id => GetArtisanAsync(authenticationScope, id));
            var artisans = await Task.WhenAll(artisanTasks);
            return artisans;
        }

        public async Task<Recipe> GetRecipeAsync(IAuthenticationScope authenticationScope, RecipeId recipeId)
        {
            var mapper = new RecipeMapper(recipeId.Id);
            var artisanSlug = EnumConversionHelper.ArtisanIdentifierToString(recipeId.Id);

            using (var client = CreateClient(authenticationScope))
            {
                var recipe = await client.GetRecipeAsync(artisanSlug, recipeId.Slug);
                return mapper.Map(recipe);
            }
        }
    }
}