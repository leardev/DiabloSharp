using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiabloSharp.DataTransferObjects;
using DiabloSharp.Tests.Infrastructure;
using NUnit.Framework;

namespace DiabloSharp.Tests.Endpoints
{
    [TestFixture]
    public class ActEndpointTests
    {
        [Test]
        public async Task GetActIndexTest()
        {
            var diabloApi = DiabloApiFactory.CreateApi();
            var authenticationScope = await diabloApi.CreateAuthenticationScopeAsync();

            var acts = await diabloApi.Act.GetActIndexAsync(authenticationScope);
            AssertActs(acts.Acts.ToList());
        }

        [Test]
        public async Task GetActTest([Range(1L, 5L)] long actId)
        {
            var diabloApi = DiabloApiFactory.CreateApi();
            var authenticationScope = await diabloApi.CreateAuthenticationScopeAsync();

            var act = await diabloApi.Act.GetActAsync(authenticationScope, actId);
            Assert.AreEqual(actId, act.Id);
            AssertAct(act);
        }

        private void AssertActs(ICollection<ActDto> acts)
        {
            Assert.AreEqual(5, acts.Count);
            foreach (var act in acts)
                AssertAct(act);
        }

        private void AssertAct(ActDto act)
        {
            Assert.NotZero(act.Id);
            Assert.That(act.Name, Is.Not.Null.Or.Empty);
            Assert.That(act.Slug, Is.Not.Null.Or.Empty);

            Assert.IsNotEmpty(act.Quests);
            foreach (var quest in act.Quests)
                AssertQuest(quest);
        }

        private void AssertQuest(ActQuestDto quest)
        {
            Assert.NotZero(quest.Id);
            Assert.That(quest.Name, Is.Not.Null.Or.Empty);
            Assert.That(quest.Slug, Is.Not.Null.Or.Empty);
        }
    }
}