using System.Collections.Generic;
using DiabloSharp.Infrastructure;

namespace DiabloSharp.Models
{
    public class FollowerSkillId : ValueObject
    {
        public FollowerSkillId(FollowerId id, string slug)
        {
            Id = id;
            Slug = slug;
        }

        public FollowerId Id { get; }

        public string Slug { get; }

        public override string ToString()
        {
            return $"{nameof(Id)} = {Id}, {nameof(Slug)} = {Slug}";
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Id;
            yield return Slug;
        }
    }
}