using System.Linq;
using System.Threading.Tasks;
using DiabloSharp.Tests.Infrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DiabloSharp.Tests.Endpoints
{
    [TestClass]
    public class ItemTypeEndpointTests
    {
        [TestMethod]
        public async Task GetItemTypeIndexTest()
        {
            var diabloApi = DiabloApiFactory.CreateApi();
            var authenticationScope = diabloApi.CreateAuthenticationScope();

            var itemTypeIndices = await diabloApi.ItemType.GetItemTypeIndexAsync(authenticationScope);
            Assert.IsTrue(itemTypeIndices.Any());
        }

        [TestMethod]
        public async Task GetItemTypeTest()
        {
            var diabloApi = DiabloApiFactory.CreateApi();
            var authenticationScope = diabloApi.CreateAuthenticationScope();

            var itemTypes = await diabloApi.ItemType.GetItemTypeAsync(authenticationScope, "item-type/sword2h");
            Assert.IsTrue(itemTypes.Any());
        }
    }
}