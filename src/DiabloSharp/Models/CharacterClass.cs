using System.Collections.Generic;
using System.Linq;

namespace DiabloSharp.Models
{
    public class CharacterClass : ModelBase<CharacterClassIdentifier>
    {
        public string Name { get; internal set; }

        public string IconUrl { get; internal set; }

        public IEnumerable<CharacterName> Names { get; internal set; }

        public IEnumerable<SkillCharacterActive> ActiveSkills { get; internal set; }

        public IEnumerable<SkillCharacterPassive> PassiveSkills { get; internal set; }

        public IEnumerable<SkillCharacter> Skills => ActiveSkills.Cast<SkillCharacter>().Concat(PassiveSkills);
    }
}