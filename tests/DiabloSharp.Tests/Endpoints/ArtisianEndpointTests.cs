using System.Threading.Tasks;
using DiabloSharp.Tests.Infrastructure;
using NUnit.Framework;

namespace DiabloSharp.Tests.Endpoints
{
    [TestFixture]
    public class ArtisianEndpointTests
    {
        [Test]
        public async Task GetArtisanTest()
        {
            var diabloApi = DiabloApiFactory.CreateApi();
            var authenticationScope = diabloApi.CreateAuthenticationScope();

            var artisan = await diabloApi.Artisan.GetArtisanAsync(authenticationScope, "blacksmith");
            Assert.AreEqual("Blacksmith", artisan.Name);
            Assert.AreEqual("blacksmith", artisan.Slug);
        }

        [Test]
        public async Task GetRecipeTest()
        {
            var diabloApi = DiabloApiFactory.CreateApi();
            var authenticationScope = diabloApi.CreateAuthenticationScope();

            var recipe = await diabloApi.Artisan.GetRecipeAsync(authenticationScope, "blacksmith", "apprentice-flamberge");
            Assert.AreEqual("Sword_2H_003", recipe.Id);
            Assert.AreEqual("Apprentice Flamberge", recipe.Name);
            Assert.AreEqual("apprentice-flamberge", recipe.Slug);
        }
    }
}