using System.Threading.Tasks;
using DiabloSharp.DataTransferObjects;
using NUnit.Framework;

namespace DiabloSharp.Tests.Clients
{
    [TestFixture]
    internal class FollowerClientTests : ClientTestsBase
    {
        [Test]
        [TestCase("templar")]
        [TestCase("scoundrel")]
        [TestCase("enchantress")]
        public async Task GetFollowerTest(string followerSlug)
        {
            var follower = await Client.GetFollowerAsync(followerSlug);
            Assert.AreEqual(followerSlug, follower.Slug);
            AssertFollower(follower);
        }

        private void AssertFollower(FollowerDto follower)
        {
            Assert.That(follower.Name, Is.Not.Null.Or.Empty);
            Assert.That(follower.Portrait, Is.Not.Null.Or.Empty);
            Assert.That(follower.RealName, Is.Not.Null.Or.Empty);
            Assert.That(follower.Slug, Is.Not.Null.Or.Empty);

            Assert.IsNotEmpty(follower.Skills);
            foreach (var skill in follower.Skills)
                AssertSkill(skill);
        }

        private void AssertSkill(FollowerSkillDto skill)
        {
            Assert.That(skill.Slug, Is.Not.Null.Or.Empty);
            Assert.That(skill.Slug, Is.Not.Null.Or.Empty);
            Assert.That(skill.Description, Is.Not.Null.Or.Empty);
            Assert.That(skill.DescriptionHtml, Is.Not.Null.Or.Empty);
            Assert.That(skill.Icon, Is.Not.Null.Or.Empty);
            Assert.That(skill.TooltipUrl, Is.Not.Null.Or.Empty);
            Assert.NotZero(skill.Level);
        }
    }
}