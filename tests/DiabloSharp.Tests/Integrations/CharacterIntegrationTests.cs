using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiabloSharp.Models;
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
        public async Task IntegrationTest(string classSlug)
        {
            var skillsTasks = GetSkillsFromCharacterClassAsync(classSlug);
            var nestedSkills = await Task.WhenAll(skillsTasks);
            var skills = nestedSkills.SelectMany(skill => skill);

            /* todo call mal richtig */
            foreach (var skill in skills)
                Assert.That(skill.Slug, Is.Not.Null.Or.Empty);
        }

        private async Task<IEnumerable<CharacterSkill>> GetSkillsFromCharacterClassAsync(string classSlug)
        {
            var diabloApi = DiabloApiFactory.CreateApi();
            var characterClass = await diabloApi.Character.GetCharacterClassAsync(_authenticationScope, classSlug);
            var activeSkills = characterClass.Skills.Actives.ToList();
            var passiveSkills = characterClass.Skills.Passives;
            return activeSkills.Concat(passiveSkills);
        }
    }
}