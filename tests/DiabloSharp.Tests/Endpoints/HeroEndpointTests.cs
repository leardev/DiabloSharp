using System.Threading.Tasks;
using DiabloSharp.Tests.Infrastructure;
using NUnit.Framework;

namespace DiabloSharp.Tests.Endpoints
{
    [TestFixture]
    public class HeroEndpointTests
    {
        [Test]
        public async Task GetHeroClassTest()
        {
            var diabloApi = DiabloApiFactory.CreateApi();
            var authenticationScope = diabloApi.CreateAuthenticationScope();

            var heroClass = await diabloApi.Hero.GetHeroClassAsync(authenticationScope, "barbarian");
            Assert.AreEqual("Barbarian", heroClass.Name);
            Assert.AreEqual("barbarian", heroClass.Slug);
            Assert.IsNotEmpty(heroClass.SkillCategories);
        }

        [Test]
        public async Task GetRunesBySkillTest()
        {
            var diabloApi = DiabloApiFactory.CreateApi();
            var authenticationScope = diabloApi.CreateAuthenticationScope();

            var runesBySkill = await diabloApi.Hero.GetRunesBySkillAsync(authenticationScope, "barbarian", "bash");
            Assert.AreEqual("Bash", runesBySkill.Skill.Name);
            Assert.AreEqual("bash", runesBySkill.Skill.Slug);
            Assert.IsNotEmpty(runesBySkill.Runes);
        }
    }
}