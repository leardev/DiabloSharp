using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DiabloSharp.Models
{
    [DataContract]
    public class CharacterSkills
    {
        [DataMember(Name = "active")]
        public IEnumerable<CharacterSkill> Actives { get; set; }

        [DataMember(Name = "passive")]
        public IEnumerable<CharacterSkill> Passives { get; set; }
    }
}