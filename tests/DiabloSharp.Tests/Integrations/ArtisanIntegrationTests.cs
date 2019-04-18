using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiabloSharp.Models;
using DiabloSharp.Tests.Infrastructure;
using NUnit.Framework;

namespace DiabloSharp.Tests.Integrations
{
    [TestFixture]
    public class ArtisanIntegrationTests
    {
        private IAuthenticationScope _authenticationScope;

        [OneTimeSetUp]
        public async Task Setup()
        {
            var diabloApi = DiabloApiFactory.CreateApi();
            _authenticationScope = await diabloApi.CreateAuthenticationScopeAsync();
        }

        [Test]
        [TestCase("blacksmith")]
        [TestCase("jeweler")]
        [TestCase("mystic")]
        [Ignore("Disabled until rate limiting (100 requests per second | 36,000 requests per hour) is implemented.")]
        public async Task IntegrationTest(string artisanSlug)
        {
            var artisanRecipes = await GetRecipesFromArtisanAsync(artisanSlug);

            var recipesTasks = artisanRecipes.Select(recipe => ProcessArtisanRecipe(artisanSlug, recipe));
            var recipes = await Task.WhenAll(recipesTasks);

            foreach (var recipe in recipes)
                Assert.That(recipe.Id, Is.Not.Null.Or.Empty);
        }

        private async Task<IEnumerable<ArtisanRecipe>> GetRecipesFromArtisanAsync(string artisanSlug)
        {
            var diabloApi = DiabloApiFactory.CreateApi();
            var artisan = await diabloApi.Artisan.GetArtisanAsync(_authenticationScope, artisanSlug);

            var trainedRecipes = artisan.Training.Tiers.SelectMany(tier => tier.TrainedRecipes);
            var taughtRecipes = artisan.Training.Tiers.SelectMany(tier => tier.TaughtRecipes);
            return trainedRecipes.Concat(taughtRecipes);
        }

        private async Task<ArtisanRecipe> ProcessArtisanRecipe(string artisanSlug, ArtisanRecipe recipe)
        {
            var diabloApi = DiabloApiFactory.CreateApi();
            return await diabloApi.Artisan.GetRecipeAsync(_authenticationScope, artisanSlug, recipe.Slug);
        }
    }
}