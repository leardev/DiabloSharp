using System.Runtime.Serialization;

namespace DiabloSharp.Models
{
    [DataContract]
    public class HeroActiveSkill
    {
        [DataMember(Name = "skill")]
        public Skill Skill { get; set; }

        [DataMember(Name = "rune")]
        public Rune Rune { get; set; }
    }
}