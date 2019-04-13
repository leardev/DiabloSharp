using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiabloSharp.Models;
using DiabloSharp.Tests.Infrastructure;
using NUnit.Framework;

namespace DiabloSharp.Tests.Endpoints
{
    [TestFixture]
    public class ActEndpointTests
    {
        [Test]
        public async Task GetActsTest()
        {
            var diabloApi = DiabloApiFactory.CreateApi();
            var authenticationScope = diabloApi.CreateAuthenticationScope();

            var acts = await diabloApi.Act.GetActs(authenticationScope);
            AssertActs(acts.ToList());
        }

        [Test]
        public async Task GetActTest([Range(1, 5)] int actId)
        {
            var diabloApi = DiabloApiFactory.CreateApi();
            var authenticationScope = diabloApi.CreateAuthenticationScope();

            var act = await diabloApi.Act.GetAct(authenticationScope, actId);
            Assert.AreEqual(actId, act.Id);
            AssertAct(act);
        }

        private void AssertActs(ICollection<Act> acts)
        {
            Assert.IsNotEmpty(acts);
            foreach (var act in acts)
                AssertAct(act);
        }

        private void AssertAct(Act act)
        {
            Assert.NotZero(act.Id);
            Assert.IsNotEmpty(act.Name);
            Assert.IsNotEmpty(act.Slug);
            Assert.IsNotEmpty(act.Quests);
            AssertQuests(act.Quests.ToList());
        }

        private void AssertQuests(ICollection<Quest> quests)
        {
            Assert.IsNotEmpty(quests);
            foreach (var quest in quests)
                AssertQuest(quest);
        }

        private void AssertQuest(Quest quest)
        {
            Assert.NotZero(quest.Id);
            Assert.IsNotEmpty(quest.Name);
            Assert.IsNotEmpty(quest.Slug);
        }
    }
}