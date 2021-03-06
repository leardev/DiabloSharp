using System.Threading.Tasks;
using DiabloSharp.DataTransferObjects;
using NUnit.Framework;

namespace DiabloSharp.Tests.Clients
{
    [TestFixture]
    internal class ItemClientTests : ClientTestsBase
    {
        [Test]
        public async Task GetItemTest()
        {
            var item = await Client.GetItemAsync("item/corrupted-ashbringer-Unique_Sword_2H_104_x1");
            AssertCorruptedAshbringer(item);
        }

        private void AssertCorruptedAshbringer(ItemDto item)
        {
            Assert.That(item.FlavorText, Is.Not.Null.Or.Empty);
            Assert.That(item.FlavorTextHtml, Is.Not.Null.Or.Empty);
            Assert.That(item.Damage, Is.Not.Null.Or.Empty);
            Assert.That(item.Dps, Is.Not.Null.Or.Empty);
            Assert.That(item.DamageHtml, Is.Not.Null.Or.Empty);
            Assert.AreEqual("Unique_Sword_2H_104_x1", item.Id);
            Assert.AreEqual("corrupted-ashbringer", item.Slug);
            Assert.AreEqual("Corrupted Ashbringer", item.Name);
            Assert.AreEqual("unique_sword_2h_104_x1_demonhunter_male", item.Icon);
            Assert.AreEqual("/item/corrupted-ashbringer-Unique_Sword_2H_104_x1", item.TooltipParams);
            Assert.AreEqual("Legendary Two-Handed Sword", item.TypeName);
            Assert.AreEqual("orange", item.Color);
            Assert.IsNull(item.Armor);
            Assert.IsNull(item.ArmorHtml);
            Assert.IsNull(item.Block);
            Assert.IsNull(item.BlockHtml);
            Assert.IsNull(item.Description);
            Assert.IsNull(item.DescriptionHtml);
            Assert.IsNull(item.SetName);
            Assert.IsNull(item.SetNameHtml);
            Assert.IsNull(item.SetDescription);
            Assert.IsNull(item.SetDescriptionHtml);
            Assert.AreEqual(-1, item.SeasonRequiredToDrop);
            Assert.AreEqual(0, item.StackSizeMax);
            Assert.AreEqual(70, item.RequiredLevel);
            Assert.IsTrue(item.AccountBound);
            Assert.IsFalse(item.IsSeasonRequiredToDrop);
            Assert.IsEmpty(item.SetItems);

            foreach (var slot in item.Slots)
                Assert.That(slot, Is.Not.Null.Or.Empty);

            foreach (var attribute in item.Attributes.Primaries)
                AssertAttribute(attribute);

            foreach (var attribute in item.Attributes.Secondaries)
                AssertAttribute(attribute);

            foreach (var attribute in item.Attributes.Others)
                AssertAttribute(attribute);

            AssertItemKind(item.Type);
        }

        private void AssertItemKind(ItemKindDto itemKind)
        {
            Assert.AreEqual("Sword2H", itemKind.Id);
            Assert.IsTrue(itemKind.TwoHanded);
        }

        private void AssertAttribute(ItemHtmlDescriptionDto attribute)
        {
            Assert.That(attribute.Text, Is.Not.Null.Or.Empty);
            Assert.That(attribute.TextHtml, Is.Not.Null.Or.Empty);
        }
    }
}