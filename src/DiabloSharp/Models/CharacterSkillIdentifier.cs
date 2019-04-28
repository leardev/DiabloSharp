using System.Collections.Generic;
using DiabloSharp.Infrastructure;

namespace DiabloSharp.Models
{
    public class CharacterSkillIdentifier : ValueObject
    {
        public CharacterSkillIdentifier(CharacterIdentifier characterId, string slug)
        {
            Id = characterId;
            Slug = slug;
        }

        public CharacterIdentifier Id { get; }

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