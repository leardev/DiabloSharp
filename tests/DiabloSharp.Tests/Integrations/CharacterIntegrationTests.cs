using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiabloSharp.DataTransferObjects;
using DiabloSharp.Tests.Infrastructure;
using NUnit.Framework;

namespace DiabloSharp.Tests.Integrations
{
    [TestFixture]
    public class CharacterIntegrationTests
    {
        private IAuthenticationScope _authenticationScope;

        [OneTimeSetUp]
        public void Setup()
        {
            var diabloApi = DiabloApiFactory.CreateApi();
            _authenticationScope = diabloApi.CreateAuthenticationScope();
        }

        [Test]
        [TestCase("barbarian")]
        [TestCase("crusader")]
        [TestCase("demon-hunter")]
        [TestCase("monk")]
        [TestCase("necromancer")]
        [TestCase("witch-doctor")]
        [TestCase("wizard")]
        [Ignore("Disabled until rate limiting (100 requests per second | 36,000 requests per hour) is implemented.")]
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
            var diabloApi = DiabloApiFactory.CreateApi();
            return await diabloApi.Character.GetApiSkillAsync(_authenticationScope, classSlug, skill.Slug);
        }

        private async Task<IEnumerable<CharacterSkillDto>> GetSkillsFromCharacterClassAsync(string classSlug)
        {
            var diabloApi = DiabloApiFactory.CreateApi();
            var characterClass = await diabloApi.Character.GetCharacterClassAsync(_authenticationScope, classSlug);
            var activeSkills = characterClass.Skills.Actives.ToList();
            var passiveSkills = characterClass.Skills.Passives;
            return activeSkills.Concat(passiveSkills);
        }
    }
}