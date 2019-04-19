using System.Threading.Tasks;
using DiabloSharp.DataTransferObjects;
using NUnit.Framework;

namespace DiabloSharp.Tests.Clients
{
    [TestFixture]
    internal class ItemTypeClientTests : ClientTestsBase
    {
        [Test]
        public async Task GetItemTypeIndexTest()
        {
            var itemTypeIndices = await Client.GetItemTypeIndexAsync();
            foreach (var itemTypeIndex in itemTypeIndices)
                AssertItemTypeIndex(itemTypeIndex);
        }

        [Test]
        public async Task GetItemTypeTest()
        {
            var itemTypes = await Client.GetItemTypeAsync("item-type/sword2h");
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