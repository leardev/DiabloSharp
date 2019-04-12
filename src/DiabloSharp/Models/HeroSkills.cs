using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DiabloSharp.Models
{
    [DataContract]
    public class HeroSkills
    {
        [DataMember(Name = "active")]
        public IEnumerable<HeroActiveSkill> Actives { get; set; }

        [DataMember(Name = "passive")]
        public IEnumerable<HeroPassiveSkill> Passives { get; set; }
    }
}