using System.Collections.Generic;
using DiabloSharp.Infrastructure;

namespace DiabloSharp.Models
{
    public class FollowerSkillIdentifier : ValueObject
    {
        public FollowerSkillIdentifier(FollowerIdentifier id, string slug)
        {
            Id = id;
            Slug = slug;
        }

        public FollowerIdentifier Id { get; }

        public string Slug { get; }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Id;
            yield return Slug;
        }

        public override string ToString()
        {
            return $"{nameof(Id)} = {Id}, {nameof(Slug)} = {Slug}";
        }
    }
}