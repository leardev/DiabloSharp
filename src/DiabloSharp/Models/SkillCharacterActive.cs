using System.Collections.Generic;

namespace DiabloSharp.Models
{
    public class SkillCharacterActive : SkillCharacter
    {
        public IEnumerable<SkillRune> Runes { get; internal set; }
    }
}