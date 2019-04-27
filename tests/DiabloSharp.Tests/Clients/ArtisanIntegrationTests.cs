using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiabloSharp.DataTransferObjects;
using NUnit.Framework;

namespace DiabloSharp.Tests.Clients
{
    [TestFixture]
    internal class ArtisanIntegrationTests : ClientTestsBase
    {
        [Test]
        [TestCase("blacksmith")]
        [TestCase("jeweler")]
        [TestCase("mystic")]
        public async Task IntegrationTest(string artisanSlug)
        {
            var artisanRecipes = await GetRecipesFromArtisanAsync(artisanSlug);

            var recipesTasks = artisanRecipes.Select(recipe => ProcessArtisanRecipe(artisanSlug, recipe));
            var recipes = await Task.WhenAll(recipesTasks);

            foreach (var recipe in recipes)
                Assert.That(recipe.Id, Is.Not.Null.Or.Empty);
        }

        private async Task<IEnumerable<ArtisanRecipeDto>> GetRecipesFromArtisanAsync(string artisanSlug)
        {
            var artisan = await Client.GetArtisanAsync(artisanSlug);

            var trainedRecipes = artisan.Training.Tiers.SelectMany(tier => tier.TrainedRecipes);
            var taughtRecipes = artisan.Training.Tiers.SelectMany(tier => tier.TaughtRecipes);
            return trainedRecipes.Concat(taughtRecipes);
        }

        private async Task<RecipeDto> ProcessArtisanRecipe(string artisanSlug, ArtisanRecipeDto recipe)
        {
            return await Client.GetRecipeAsync(artisanSlug, recipe.Slug);
        }
    }
}