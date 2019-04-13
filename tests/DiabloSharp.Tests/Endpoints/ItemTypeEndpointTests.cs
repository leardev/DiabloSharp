using System.Threading.Tasks;
using DiabloSharp.Tests.Infrastructure;
using NUnit.Framework;

namespace DiabloSharp.Tests.Endpoints
{
    [TestFixture]
    public class ItemTypeEndpointTests
    {
        [Test]
        public async Task GetItemTypeIndexTest()
        {
            var diabloApi = DiabloApiFactory.CreateApi();
            var authenticationScope = diabloApi.CreateAuthenticationScope();

            var itemTypeIndices = await diabloApi.ItemType.GetItemTypeIndexAsync(authenticationScope);
            Assert.IsNotEmpty(itemTypeIndices);
        }

        [Test]
        public async Task GetItemTypeTest()
        {
            var diabloApi = DiabloApiFactory.CreateApi();
            var authenticationScope = diabloApi.CreateAuthenticationScope();

            var itemTypes = await diabloApi.ItemType.GetItemTypeAsync(authenticationScope, "item-type/sword2h");
            Assert.IsNotEmpty(itemTypes);
        }
    }
}