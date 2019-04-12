using System.Linq;
using System.Threading.Tasks;
using DiabloSharp.Tests.Infrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DiabloSharp.Tests.Endpoints
{
    [TestClass]
    public class HeroEndpointTests
    {
        [TestMethod]
        public async Task GetHeroClassTest()
        {
            var diabloApi = DiabloApiFactory.CreateApi();
            var authenticationScope = diabloApi.CreateAuthenticationScope();

            var heroClass = await diabloApi.Hero.GetHeroClassAsync(authenticationScope, "barbarian");
            Assert.AreEqual("Barbarian", heroClass.Name);
            Assert.AreEqual("barbarian", heroClass.Slug);
            Assert.IsTrue(heroClass.SkillCategories.Any());
        }

        [TestMethod]
        public async Task GetRunesBySkillTest()
        {
            var diabloApi = DiabloApiFactory.CreateApi();
            var authenticationScope = diabloApi.CreateAuthenticationScope();

            var runesBySkill = await diabloApi.Hero.GetRunesBySkillAsync(authenticationScope, "barbarian", "bash");
            Assert.AreEqual("Bash", runesBySkill.Skill.Name);
            Assert.AreEqual("bash", runesBySkill.Skill.Slug);
            Assert.IsTrue(runesBySkill.Runes.Any());
        }
    }
}