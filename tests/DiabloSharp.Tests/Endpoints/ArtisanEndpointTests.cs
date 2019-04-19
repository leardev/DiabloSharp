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
            var recipe = await DiabloApi.Artisan.GetRecipeAsync(AuthenticationScope, ArtisanIdentifier.Blacksmith, "apprentice-flamberge");
            Assert.IsNotNull(recipe);
        }
    }
}