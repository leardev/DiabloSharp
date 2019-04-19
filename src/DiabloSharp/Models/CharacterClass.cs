using System.Collections.Generic;

namespace DiabloSharp.Models
{
    public class CharacterClass : ModelBase<CharacterClassIdentifier>
    {
        public string Name { get; internal set; }

        public string IconUrl { get; internal set; }

        public IDictionary<Gender, string> NamesByGender { get; internal set; }

        public IEnumerable<Skill> Skills { get; internal set; }
    }
}