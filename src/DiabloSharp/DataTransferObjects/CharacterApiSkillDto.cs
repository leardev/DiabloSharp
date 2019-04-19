using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DiabloSharp.DataTransferObjects
{
    [DataContract]
    public class CharacterApiSkillDto
    {
        [DataMember(Name = "skill")]
        public CharacterSkillDto Skill { get; set; }

        [DataMember(Name = "runes")]
        public IEnumerable<CharacterRuneDto> Runes { get; set; }
    }
}