using System.Collections.Generic;
using DiabloSharp.Infrastructure;

namespace DiabloSharp.Models
{
    public class SkillCharacterIdentifier : ValueObject
    {
        public SkillCharacterIdentifier(CharacterIdentifier characterId, string slug)
        {
            Class = characterId;
            Slug = slug;
        }

        public CharacterIdentifier Class { get; }

        public string Slug { get; }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Class;
            yield return Slug;
        }

        public override string ToString()
        {
            return $"{nameof(Class)} = {Class}, {nameof(Slug)} = {Slug}";
        }
    }
}