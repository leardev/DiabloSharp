using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DiabloSharp.Models
{
    [DataContract]
    public class Skills
    {
        [DataMember(Name = "active")]
        public IEnumerable<Skill> Actives { get; set; }

        [DataMember(Name = "passive")]
        public IEnumerable<Skill> Passives { get; set; }
    }
}