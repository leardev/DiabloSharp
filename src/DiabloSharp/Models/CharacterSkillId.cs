using System.Collections.Generic;
using DiabloSharp.Infrastructure;

namespace DiabloSharp.Models
{
    public class CharacterSkillId : ValueObject
    {
        public CharacterSkillId(string id, string slug)
        {
            Id = id;
            Slug = slug;
        }

        public string Id { get; }

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