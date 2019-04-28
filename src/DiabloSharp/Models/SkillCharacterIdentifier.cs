using System.Collections.Generic;
using DiabloSharp.Infrastructure;

namespace DiabloSharp.Models
{
    public class SkillCharacterIdentifier : ValueObject
    {
        public SkillCharacterIdentifier(CharacterClassIdentifier characterClass, string slug)
        {
            Class = characterClass;
            Slug = slug;
        }

        public CharacterClassIdentifier Class { get; }

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