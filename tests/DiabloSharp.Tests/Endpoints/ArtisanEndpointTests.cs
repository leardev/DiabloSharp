using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiabloSharp.Models;
using DiabloSharp.Tests.Infrastructure;
using NUnit.Framework;

namespace DiabloSharp.Tests.Endpoints
{
    [TestFixture]
    public class ArtisanEndpointTests
    {
        [Test]
        [TestCase("blacksmith")]
        [TestCase("jeweler")]
        [TestCase("mystic")]
        public async Task GetArtisanTest(string artisanSlug)
        {
            var diabloApi = DiabloApiFactory.CreateApi();
            var authenticationScope = diabloApi.CreateAuthenticationScope();

            var artisan = await diabloApi.Artisan.GetArtisanAsync(authenticationScope, artisanSlug);
            Assert.AreEqual(artisanSlug, artisan.Slug);
            AssertArtisan(artisan);
        }

        [Test]
        public async Task GetRecipeTest()
        {
            var diabloApi = DiabloApiFactory.CreateApi();
            var authenticationScope = diabloApi.CreateAuthenticationScope();

            var recipe = await diabloApi.Artisan.GetRecipeAsync(authenticationScope, "blacksmith", "apprentice-flamberge");
            AssertRecipe(recipe);
        }

        private void AssertArtisan(Artisan artisan)
        {
            Assert.That(artisan.Name, Is.Not.Null.Or.Empty);
            Assert.That(artisan.Portrait, Is.Not.Null.Or.Empty);

            Assert.IsNotEmpty(artisan.Training.Tiers);
            AssertTiers(artisan.Training.Tiers.ToList());
        }

        private void AssertTiers(ICollection<ArtisanTier> tiers)
        {
            Assert.IsNotEmpty(tiers);
            foreach (var tier in tiers)
                AssertTier(tier);
        }

        private void AssertTier(ArtisanTier tier)
        {
            Assert.NotZero(tier.Index);
            foreach (var recipe in tier.TrainedRecipes)
                AssertRecipe(recipe);
            foreach (var recipe in tier.TaughtRecipes)
                AssertRecipe(recipe);
        }

        private void AssertRecipe(ArtisanRecipe recipe)
        {
            Assert.That(recipe.Name, Is.Not.Null.Or.Empty);
            Assert.That(recipe.Id, Is.Not.Null.Or.Empty);
            Assert.That(recipe.Slug, Is.Not.Null.Or.Empty);
            Assert.NotZero(recipe.Cost);

            AssertItemType(recipe.ItemProduced);
            foreach (var reagent in recipe.Reagents)
                AssertReagent(reagent);
        }

        private void AssertItemType(ArtisanItemType itemType)
        {
            Assert.That(itemType.Name, Is.Not.Null.Or.Empty);
            Assert.That(itemType.Icon, Is.Not.Null.Or.Empty);
            Assert.That(itemType.Id, Is.Not.Null.Or.Empty);
            Assert.That(itemType.Path, Is.Not.Null.Or.Empty);
            Assert.That(itemType.Slug, Is.Not.Null.Or.Empty);
        }

        private void AssertReagent(ArtisanReagent reagent)
        {
            Assert.NotZero(reagent.Quantity);
            AssertItemType(reagent.Item);
        }
    }
}