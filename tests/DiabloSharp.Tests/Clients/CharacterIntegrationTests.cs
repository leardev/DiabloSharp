using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiabloSharp.DataTransferObjects;
using NUnit.Framework;

namespace DiabloSharp.Tests.Clients
{
    [TestFixture]
    internal class CharacterIntegrationTests : ClientTestsBase
    {
        [Test]
        [TestCase("barbarian")]
        [TestCase("crusader")]
        [TestCase("demon-hunter")]
        [TestCase("monk")]
        [TestCase("necromancer")]
        [TestCase("witch-doctor")]
        [TestCase("wizard")]
        public async Task IntegrationTest(string classSlug)
        {
            var skillsTasks = GetSkillsFromCharacterClassAsync(classSlug);
            var nestedSkills = await Task.WhenAll(skillsTasks);
            var skills = nestedSkills.SelectMany(skill => skill);

            var apiSkillsTasks = skills.Select(characterSkill => ProcessSkill(classSlug, characterSkill));
            var apiSkills = await Task.WhenAll(apiSkillsTasks);

            foreach (var apiSkill in apiSkills)
                Assert.That(apiSkill.Skill.Slug, Is.Not.Null.Or.Empty);
        }

        private async Task<CharacterApiSkillDto> ProcessSkill(string classSlug, CharacterSkillDto skill)
        {
            return await Client.GetApiSkillAsync(classSlug, skill.Slug);
        }

        private async Task<IEnumerable<CharacterSkillDto>> GetSkillsFromCharacterClassAsync(string classSlug)
        {
            var characterClass = await Client.GetCharacterClassAsync(classSlug);
            var activeSkills = characterClass.Skills.Actives.ToList();
            var passiveSkills = characterClass.Skills.Passives;
            return activeSkills.Concat(passiveSkills);
        }
    }
}