using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DiabloSharp.Models
{
    [DataContract]
    public class CharacterApiSkill
    {
        [DataMember(Name = "skill")]
        public CharacterSkill Skill { get; set; }

        [DataMember(Name = "runes")]
        public IEnumerable<CharacterRune> Runes { get; set; }
    }
}