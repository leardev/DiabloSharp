using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DiabloSharp.DataTransferObjects
{
    [DataContract]
    internal class HeroSkillsDto
    {
        [DataMember(Name = "active")]
        public IEnumerable<HeroActiveSkillDto> Actives { get; set; }

        [DataMember(Name = "passive")]
        public IEnumerable<HeroPassiveSkillDto> Passives { get; set; }
    }
}