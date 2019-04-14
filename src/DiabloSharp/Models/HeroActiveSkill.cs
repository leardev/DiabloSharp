using System.Runtime.Serialization;

namespace DiabloSharp.Models
{
    [DataContract]
    public class HeroActiveSkill
    {
        [DataMember(Name = "skill")]
        public HeroSkill Skill { get; set; }

        [DataMember(Name = "rune")]
        public HeroRune Rune { get; set; }
    }
}