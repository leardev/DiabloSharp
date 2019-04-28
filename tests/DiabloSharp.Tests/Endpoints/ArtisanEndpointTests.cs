using System.Threading.Tasks;
using DiabloSharp.Models;
using NUnit.Framework;

namespace DiabloSharp.Tests.Endpoints
{
    [TestFixture]
    public class ArtisanEndpointTests : EndpointTestsBase
    {
        [Test]
        public async Task GetArtisanTest()
        {
            var artisan = await DiabloApi.Artisan.GetArtisanAsync(AuthenticationScope, ArtisanIdentifier.Blacksmith);
            Assert.IsNotNull(artisan);
        }

        [Test]
        public async Task GetRecipeTest()
        {
            var recipeId = new RecipeIdentifier(ArtisanIdentifier.Blacksmith, "apprentice-flamberge");
            var recipe = await DiabloApi.Artisan.GetRecipeAsync(AuthenticationScope, recipeId);
            Assert.IsNotNull(recipe);
        }
    }
}