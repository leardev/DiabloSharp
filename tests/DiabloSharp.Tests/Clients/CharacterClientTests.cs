using System.Threading.Tasks;
using DiabloSharp.DataTransferObjects;
using NUnit.Framework;

namespace DiabloSharp.Tests.Clients
{
    [TestFixture]
    internal class CharacterClientTests : ClientTestsBase
    {
        [Test]
        [TestCase("barbarian")]
        [TestCase("crusader")]
        [TestCase("demon-hunter")]
        [TestCase("monk")]
        [TestCase("necromancer")]
        [TestCase("witch-doctor")]
        [TestCase("wizard")]
        public async Task GetCharacterClassTest(string classSlug)
        {
            var characterClass = await Client.GetCharacterClassAsync(classSlug);
            AssertCharacterClass(characterClass);
        }

        [Test]
        public async Task GetApiSkillTest()
        {
            var apiSkill = await Client.GetApiSkillAsync("barbarian", "bash");

            AssertSkill(apiSkill.Skill);
            foreach (var rune in apiSkill.Runes)
                AssertRune(rune);
        }

        private void AssertCharacterClass(CharacterClassDto characterClass)
        {
            Assert.That(characterClass.Name, Is.Not.Null.Or.Empty);
            Assert.That(characterClass.FemaleName, Is.Not.Null.Or.Empty);
            Assert.That(characterClass.Icon, Is.Not.Null.Or.Empty);
            Assert.That(characterClass.MaleName, Is.Not.Null.Or.Empty);
            Assert.That(characterClass.Slug, Is.Not.Null.Or.Empty);

            foreach (var skillCategory in characterClass.SkillCategories)
                AssertSkillCategories(skillCategory);

            foreach (var activeSkill in characterClass.Skills.Actives)
                AssertSkill(activeSkill);

            foreach (var passiveSkill in characterClass.Skills.Passives)
                AssertSkill(passiveSkill);
        }

        private void AssertSkillCategories(CharacterSkillCategoryDto skillCategory)
        {
            Assert.That(skillCategory.Name, Is.Not.Null.Or.Empty);
            Assert.That(skillCategory.Slug, Is.Not.Null.Or.Empty);
        }

        private void AssertSkill(CharacterSkillDto skill)
        {
            Assert.That(skill.Name, Is.Not.Null.Or.Empty);
            Assert.That(skill.Description, Is.Not.Null.Or.Empty);
            Assert.That(skill.DescriptionHtml, Is.Not.Null.Or.Empty);
            Assert.That(skill.Icon, Is.Not.Null.Or.Empty);
            Assert.That(skill.Slug, Is.Not.Null.Or.Empty);
            Assert.That(skill.TooltipUrl, Is.Not.Null.Or.Empty);
            //Assert.That(skill.FlavorText, Is.Not.Null.Or.Empty); optional
            Assert.NotZero(skill.Level);
        }

        private void AssertRune(CharacterRuneDto rune)
        {
            Assert.That(rune.Name, Is.Not.Null.Or.Empty);
            Assert.That(rune.Description, Is.Not.Null.Or.Empty);
            Assert.That(rune.DescriptionHtml, Is.Not.Null.Or.Empty);
            Assert.That(rune.Slug, Is.Not.Null.Or.Empty);
            Assert.That(rune.Type, Is.Not.Null.Or.Empty);
            Assert.NotZero(rune.Level);
        }
    }
}