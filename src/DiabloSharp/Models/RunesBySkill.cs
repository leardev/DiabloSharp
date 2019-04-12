using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DiabloSharp.Models
{
    [DataContract]
    public class RunesBySkill
    {
        [DataMember(Name = "skill")]
        public Skill Skill { get; set; }

        [DataMember(Name = "runes")]
        public IEnumerable<Rune> Runes { get; set; }
    }
}