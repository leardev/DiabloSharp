using System.Collections.Generic;

namespace DiabloSharp.Models
{
    public class CharacterSkillActive : CharacterSkill
    {
        public IEnumerable<CharacterSkillActiveRune> Runes { get; internal set; }
    }
}