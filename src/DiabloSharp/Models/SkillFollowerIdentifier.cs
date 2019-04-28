using System.Collections.Generic;
using DiabloSharp.Infrastructure;

namespace DiabloSharp.Models
{
    public class SkillFollowerIdentifier : ValueObject
    {
        public SkillFollowerIdentifier(FollowerIdentifier followerId, string slug)
        {
            FollowerId = followerId;
            Slug = slug;
        }

        public FollowerIdentifier FollowerId { get; }

        public string Slug { get; }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return FollowerId;
            yield return Slug;
        }

        public override string ToString()
        {
            return $"{nameof(FollowerId)} = {FollowerId}, {nameof(Slug)} = {Slug}";
        }
    }
}