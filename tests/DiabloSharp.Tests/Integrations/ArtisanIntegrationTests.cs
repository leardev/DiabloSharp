using System.Linq;
using System.Threading.Tasks;
using DiabloSharp.Tests.Infrastructure;
using NUnit.Framework;

namespace DiabloSharp.Tests.Integrations
{
    [TestFixture]
    public class ArtisanIntegrationTests
    {
        [Test]
        [TestCase("blacksmith")]
        [TestCase("jeweler")]
        [TestCase("mystic")]
        public async Task IntegrationTest(string artisanSlug)
        {
            var diabloApi = DiabloApiFactory.CreateApi();
            var authenticationScope = diabloApi.CreateAuthenticationScope();

            var artisan = await diabloApi.Artisan.GetArtisanAsync(authenticationScope, artisanSlug);

            var trainedRecipes = artisan.Training.Tiers.SelectMany(tier => tier.TrainedRecipes);
            var taughtRecipes = artisan.Training.Tiers.SelectMany(tier => tier.TaughtRecipes);
            var recipes = trainedRecipes.Concat(taughtRecipes);

            foreach (var recipe in recipes)
            {
                var x = await diabloApi.Artisan.GetRecipeAsync(authenticationScope, artisanSlug, recipe.Slug);
                Assert.AreEqual(recipe.Id, x.Id);
            }
        }
    }
}