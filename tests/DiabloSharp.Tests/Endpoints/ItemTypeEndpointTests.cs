using System.Threading.Tasks;
using DiabloSharp.DataTransferObjects;
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
            var authenticationScope = await diabloApi.CreateAuthenticationScopeAsync();

            var itemTypeIndices = await diabloApi.ItemType.GetItemTypeIndexAsync(authenticationScope);
            foreach (var itemTypeIndex in itemTypeIndices)
                AssertItemTypeIndex(itemTypeIndex);
        }

        [Test]
        public async Task GetItemTypeTest()
        {
            var diabloApi = DiabloApiFactory.CreateApi();
            var authenticationScope = await diabloApi.CreateAuthenticationScopeAsync();

            var itemTypes = await diabloApi.ItemType.GetItemTypeAsync(authenticationScope, "item-type/sword2h");
            foreach (var itemType in itemTypes)
                AssertItemType(itemType);
        }

        private void AssertItemType(ItemTypeDto itemType)
        {
            Assert.That(itemType.Id, Is.Not.Null.Or.Empty);
            Assert.That(itemType.Icon, Is.Not.Null.Or.Empty);
            Assert.That(itemType.Name, Is.Not.Null.Or.Empty);
            Assert.That(itemType.Path, Is.Not.Null.Or.Empty);
            Assert.That(itemType.Slug, Is.Not.Null.Or.Empty);
        }

        private void AssertItemTypeIndex(ItemTypeIndexDto itemTypeIndex)
        {
            Assert.That(itemTypeIndex.Id, Is.Not.Null.Or.Empty);
            Assert.That(itemTypeIndex.Name, Is.Not.Null.Or.Empty);
            Assert.That(itemTypeIndex.Path, Is.Not.Null.Or.Empty);
        }
    }
}