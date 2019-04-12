using System.Linq;
using System.Threading.Tasks;
using DiabloSharp.Tests.Infrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DiabloSharp.Tests.Endpoints
{
    [TestClass]
    public class ArtisianEndpointTests
    {
        [TestMethod]
        public async Task GetArtisanTest()
        {
            var diabloApi = DiabloApiFactory.CreateApi();
            var authenticationScope = diabloApi.CreateAuthenticationScope();

            var artisan = await diabloApi.Artisian.GetArtisanAsync(authenticationScope, "blacksmith");
            Assert.AreEqual("Blacksmith", artisan.Name);
            Assert.AreEqual("blacksmith", artisan.Slug);
        }

        [TestMethod]
        public async Task GetRecipeTest()
        {
            var diabloApi = DiabloApiFactory.CreateApi();
            var authenticationScope = diabloApi.CreateAuthenticationScope();

            var recipe = await diabloApi.Artisian.GetRecipeAsync(authenticationScope, "blacksmith", "apprentice-flamberge");
            Assert.AreEqual("Sword_2H_003", recipe.Id);
            Assert.AreEqual("Apprentice Flamberge", recipe.Name);
            Assert.AreEqual("apprentice-flamberge", recipe.Slug);
        }
    }
}