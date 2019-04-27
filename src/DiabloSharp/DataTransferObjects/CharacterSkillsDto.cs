using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DiabloSharp.DataTransferObjects
{
    [DataContract]
    internal class CharacterSkillsDto
    {
        [DataMember(Name = "active")]
        public IEnumerable<CharacterSkillDto> Actives { get; set; }

        [DataMember(Name = "passive")]
        public IEnumerable<CharacterSkillDto> Passives { get; set; }
    }
}