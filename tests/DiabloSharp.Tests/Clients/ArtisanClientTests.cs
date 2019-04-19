using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiabloSharp.DataTransferObjects;
using NUnit.Framework;

namespace DiabloSharp.Tests.Clients
{
    [TestFixture]
    internal class ArtisanClientTests : ClientTestsBase
    {
        [Test]
        [TestCase("blacksmith")]
        [TestCase("jeweler")]
        [TestCase("mystic")]
        public async Task GetArtisanTest(string artisanSlug)
        {
            var artisan = await Client.GetArtisanAsync(artisanSlug);
            Assert.AreEqual(artisanSlug, artisan.Slug);
            AssertArtisan(artisan);
        }

        [Test]
        public async Task GetRecipeTest()
        {
            var recipe = await Client.GetRecipeAsync("blacksmith", "apprentice-flamberge");
            AssertRecipe(recipe);
        }

        private void AssertArtisan(ArtisanDto artisan)
        {
            Assert.That(artisan.Name, Is.Not.Null.Or.Empty);
            Assert.That(artisan.Portrait, Is.Not.Null.Or.Empty);

            Assert.IsNotEmpty(artisan.Training.Tiers);
            AssertTiers(artisan.Training.Tiers.ToList());
        }

        private void AssertTiers(ICollection<ArtisanTierDto> tiers)
        {
            Assert.IsNotEmpty(tiers);
            foreach (var tier in tiers)
                AssertTier(tier);
        }

        private void AssertTier(ArtisanTierDto tier)
        {
            Assert.NotZero(tier.Index);
            foreach (var recipe in tier.TrainedRecipes)
                AssertRecipe(recipe);
            foreach (var recipe in tier.TaughtRecipes)
                AssertRecipe(recipe);
        }

        private void AssertRecipe(ArtisanRecipeDto recipe)
        {
            Assert.That(recipe.Name, Is.Not.Null.Or.Empty);
            Assert.That(recipe.Id, Is.Not.Null.Or.Empty);
            Assert.That(recipe.Slug, Is.Not.Null.Or.Empty);
            Assert.NotZero(recipe.Cost);

            AssertItemType(recipe.ItemProduced);
            foreach (var reagent in recipe.Reagents)
                AssertReagent(reagent);
        }

        private void AssertItemType(ArtisanItemTypeDto itemType)
        {
            Assert.That(itemType.Name, Is.Not.Null.Or.Empty);
            Assert.That(itemType.Icon, Is.Not.Null.Or.Empty);
            Assert.That(itemType.Id, Is.Not.Null.Or.Empty);
            Assert.That(itemType.Path, Is.Not.Null.Or.Empty);
            Assert.That(itemType.Slug, Is.Not.Null.Or.Empty);
        }

        private void AssertReagent(ArtisanReagentDto reagent)
        {
            Assert.NotZero(reagent.Quantity);
            AssertItemType(reagent.Item);
        }
    }
}